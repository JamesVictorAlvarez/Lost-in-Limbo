using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCabinet : MonoBehaviour
{
    public float maxDistance = 1.7f;
    public LayerMask layer;
    public float rotSpeed = 1.5f;
    public GameObject openText;
    private bool inRange;
    private GameObject cabinet;
    private OpenCabinet script;
    private AudioSource cabinetSound;

    void Start()
    {
        openText.SetActive(false);
        cabinetSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Check if the object hit by the raycast is a cabinet.
            if (hit.collider.CompareTag("Cabinet"))
            {
                inRange = true;
                openText.SetActive(true);
                GameObject newCabinet = hit.collider.gameObject;
                if (newCabinet != cabinet)
                {
                    // If a new cabinet is detected, store it.
                    cabinet = newCabinet;
                }
            }
        }
        else
        {
            cabinet = null;
            inRange = false;
            openText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact") && inRange && cabinet != null)
        {
            script = cabinet.GetComponent<OpenCabinet>();
            script.InteractWithCabinet();
        }
    }
}
