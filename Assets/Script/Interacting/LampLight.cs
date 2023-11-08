using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight : MonoBehaviour
{
    public float maxDistance = 1.2f;
    public LayerMask layer;
    public GameObject onText;
    private bool inRange;
    private GameObject lamp;
    private AudioSource lampSound;
    private Light light;
    private bool isOn;

    void Start()
    {
        onText.SetActive(false);
        lampSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Check if the object hit by the raycast is a lamp.
            if (hit.collider.CompareTag("Lamp"))
            {
                inRange = true;
                onText.SetActive(true);
                GameObject newLamp = hit.collider.gameObject;
                if (newLamp != lamp)
                {
                    // If a new lamp is detected, store it.
                    lamp = newLamp;
                }
            }
        }
        else
        {
            lamp = null;
            inRange = false;
            onText.SetActive(false);
        }
        if (Input.GetButtonDown("Interact") && inRange && lamp != null)
        {
            isOn = !isOn;
            light = lamp.transform.Find("Light").GetComponent<Light>();
            if (isOn)
                light.enabled = true;
            else light.enabled = false;
        }
    }

}
