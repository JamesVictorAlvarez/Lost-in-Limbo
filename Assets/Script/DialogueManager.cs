using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textComponent;
    public float maxDistance = 1.7f;
    public LayerMask layer;
    public float rotSpeed = 1f;
    public GameObject openText;
    public GameObject player;
    private bool inRange;
    private GameObject door;
    private OpenDoor script;
    private AudioSource doorSound;
    private string[] lines = {
        "hello",
        "this is a test"
    };
    private float textSpeed = 0.1f;
    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        InputMouse();
    }

    void InputMouse()
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

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
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

    void OpenDoorDialogue()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Check if the object hit by the raycast is a door.
            if (hit.collider.CompareTag("Door"))
            {
                inRange = true;
                openText.SetActive(true);
                if (hit.collider.gameObject != door)
                {
                    if (Input.GetButtonDown("Interact"))
                    {
                        StartDialogue();
                    }
                }
            }
        }
    }
}
