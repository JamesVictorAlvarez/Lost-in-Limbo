using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDrawer : MonoBehaviour
{
    public float maxDistance = 1.7f;
    public LayerMask layer;
    public float rotSpeed = 1.5f;
    public GameObject openText;
    private bool inRange;
    private GameObject drawer;
    private OpenDrawer script;
    private AudioSource drawerSound;

    void Start()
    {
        openText.SetActive(false);
        drawerSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Check if the object hit by the raycast is a cabinet.
            if (hit.collider.CompareTag("Drawer"))
            {
                inRange = true;
                openText.SetActive(true);
                GameObject newDrawer = hit.collider.gameObject;
                if (newDrawer != drawer)
                {
                    // If a new cabinet is detected, store it.
                    drawer = newDrawer;
                }
            }
        }
        else
        {
            drawer = null;
            inRange = false;
            openText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact") && inRange && drawer != null)
        {
            script = drawer.GetComponent<OpenDrawer>();
            script.InteractWithDrawer();
        }
    }
}
