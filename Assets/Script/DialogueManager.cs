using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent;
    private float timer = 0;
    private string[] lines = {
        "Did I fall asleep in the bus? Where am I…?",
        "That’s… my house?",
        "I guess this is my stop. Maybe I’m just really tired.",
        "Guess I’ll charge my phone first.",
        "Why does this room feel… different? Honey, are you home?",
        "A newspaper? Last time I had one was in 2015!",
        "Everything’s fine. Maybe Jimmy had some homework, and his teacher gave him this. Melanie? Are you home?",
        "Where is everything? What the hell is going on?",
        "I remember having a bed in this room… Did someone move the furniture?",
        "This doll is Lili’s favorite. Don’t see why, it looks horrible.",
        "Melanie has so many crèmes and shampoos… Where did they all go?",
        "Who goes there?! You! Stay away from me! I-I’m already gone, my sanity is so low a-and I don’t have almond water. Just leave and let me die alone!",
        "What the hell are you saying? You’re the one in MY house! You get out! What have you done to the furniture?! I’ll just call the police!",
        "You… You will call the police? How? The phones don’t work… Is this a trick?",
        "Trick?!",
        "Take a look around you. Do you see any phones? Are you… You’re sane. You’re new!",
        "What are you babbling about? You lost your mind!",
        "I have, but we might have a chance now that we’re two… What’s your name? Mine is Albert. I can remember that at least. Do you even know where you are? This is not your house.",
        "Of course, this is my house!",
        "So, you just have the bed in the living room? A collection of closets in your master bedroom? No… this isn’t your house. These are the backrooms. You’re lost.",
        "The backrooms? A simple scary story! They don’t exist.",
        "Then by all means, keep running around in despair. No one will show up. I’ve been here for 4 days! B-But now… Now…",
        "Now what?",
        "Now we can open the basement! It might be the way out! We’ll be free!",
        "Yes, yes! I had already found them, but I couldn’t do it alone! Now, we can go!",
        "What are you babbling about you fool?",
        "Good sir, take a second to think. You’re in a house in disarray, no one else is around. Did you try opening the door? It’s locked. Now, where’s the key?",
        "In my pocket, you idiot.",
        "They’re… they’re empty.",
        "Well, idiot, now will you help me?",
        "Fine. What is your plan then?",
        "There’s a key. I think it’s to access the basement. The problem is that it’s locked behind a glass that I can’t destroy, and we can only open it by pressing two buttons at the same time.",
        "You see on that wall? There’s a black button. I have a white one on this side. Let’s press them at the same time, it might open the box!",
        "What’s all this glass?",
        "Yeah, sorry about that. I tried using some glasses from the kitchen and throw them on the button while I was on this side, but… Nothing worked. B-But now-",
        "Yes, yes, I am here. I’ll do it.",
        "R-Right."
    };
    private float textSpeed = 0.1f;
    private int index;
    private int lastIndex;

    public static DialogueManager Instance { get; private set; }

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue(0,2);
    }

    public void Update()
    {
        InputMouse();
    }

    public void InputMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            } else {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue(int firstLine, int lastLine)
    {
        index = firstLine;
        lastIndex = lastLine;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if(index < lastIndex)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void PauseGame ()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}
