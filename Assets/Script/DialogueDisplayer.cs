using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dialogue;

public class DialogueDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public DialogueObject currentDialogue;
    public string [] dialogue = new Dialogue().get; 

    private void Start()
    {
        DisplayDialogue(dialogue);
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dialogueObject)
    {
        for(int i = 0; i < dialogueObject.dialogueLines.Length; i++)
        {
            dialogueText.text = dialogueObject.dialogueLines[i].dialogue;
        
            //The following line of code makes it so that the for loop is paused until the user clicks the left mouse button.
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
            //The following line of codes make the coroutine wait for a frame so as the next WaitUntil is not skipped
            yield return null;
        }
        dialogueBox.SetActive(false);
    }
    
    public void DisplayDialogue(string [] dialogueObject)
    {
        StartCoroutine(MoveThroughDialogue(dialogueObject));
    }
}