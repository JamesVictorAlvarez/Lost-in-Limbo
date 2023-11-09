using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent;
    private string[] lines = {
        "this is line 1",
        "this is line 2",
        "this is line 3",
        "this is line 4",
        "this is line 5",
        "this is line 6"
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
}
