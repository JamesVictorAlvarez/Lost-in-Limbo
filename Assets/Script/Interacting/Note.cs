using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject note;
    public TMP_Text noteTextInput;
    public string text;
    public GameObject player;
    private FirstPersonController script;

    void Start()
    {
        script = player.GetComponent<FirstPersonController>();
    }

    void Update()
    {
        if (script.enabled == false)
        {
            //Debug.Log("disabled");
            if (Input.GetButtonDown("Interact"))
            {
                HideNote();
                Debug.Log("Hide note is called");
            }
        }
    }

    public void ShowNote()
    {
        noteTextInput.text = text;
        note.SetActive(true);
        script.enabled = false;
        Debug.Log("the movement is:" + script.enabled);
    }

    public void HideNote()
    {
        note.SetActive(false);
        script.enabled = true;
        Debug.Log("the movement is:" + script.enabled);
    }

}
