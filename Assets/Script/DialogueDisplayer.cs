using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueDisplayer : MonoBehaviour
{
    // [SerializeField] private GameObject dialogueBox;
    // [SerializeField] private TMP_Text dialogueText;
    // public DialogueObject currentDialogue;
    // public TextMeshProGUI textComponent;
    // private string[] dialogue = {
    //     "hello",
    //     "this is a test"
    // };
    // private float textSpeed = 0.5f;
    // private int index;

    // private void Start()
    // {
    //     // DisplayDialogue(currentDialogue);
    //     textComponent.text = string.Empty;
    //     StartDialogue();
    // }

    // void StartDialogue()
    // {
    //     index = 0;
    //     StartCoroutine(TypeLine());
    // }

    // private IEnumerator TypeLine()
    // {
    //     foreach(char c in lines[index].ToCharArray())
    //     {
    //         textComponent.text += c;
    //         yield return new WaitForSeconds(textSpeed);
    //     }
    // }
}

    // private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    // {
    //     for(int i = 0; i < dialogueObject.dialogueLines.Length; i++)
    //     {
    //         dialogueText.text = dialogueObject.dialogueLines[i].dialogue;
        
    //         //The following line of code makes it so that the for loop is paused until the user clicks the left mouse button.
    //         yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
    //         //The following line of codes make the coroutine wait for a frame so as the next WaitUntil is not skipped
    //         yield return null;
    //     }
    //     dialogueBox.SetActive(false);
    // }
    
    // public void DisplayDialogue(DialogueObject dialogueObject)
    // {
    //     StartCoroutine(MoveThroughDialogue(dialogueObject));
    // }