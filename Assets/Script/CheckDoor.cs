using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDoor : MonoBehaviour
{
    public float maxDistance = 1.7f;
    public LayerMask layer;
    public float rotSpeed = 1f;
    public GameObject openText;
    private bool inRange;
    private GameObject door;
    private OpenDoor script;

    void Start()
    {
        openText.SetActive(false);
    }

    void Update()
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
                GameObject newDoor = hit.collider.gameObject;
                if (newDoor != door)
                {
                    // If a new door is detected, store it.
                    door = newDoor;
                }
            }
        }
        else
        {
            door = null;
            inRange = false;
            openText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact") && inRange && door != null)
        {
            script = door.GetComponent<OpenDoor>();
            script.InteractWithDoor();
        }
    }
}
