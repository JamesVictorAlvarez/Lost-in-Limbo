using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBattery : MonoBehaviour
{
    private bool inRange = false;
    public float maxDistance = 8.0f;
    public LayerMask layer;
    public GameObject pickUpText;
    private GameObject battery;

    private void Start()
    {
        pickUpText.SetActive(false);
    }

    void Update()
    {
        // Creating new ray
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Check if the object hit by the raycast is the battery.
            if (hit.collider.CompareTag("Battery"))
            {
                inRange = true;
                pickUpText.SetActive(true);
                GameObject newBattery = hit.collider.gameObject;
                if (newBattery != battery)
                {
                    // If a new battery is detected, store it.
                    battery = newBattery;
                }
            }
        }
        else
        {
            battery = null;
            inRange = false;
            pickUpText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact") && inRange && battery != null)
        {
            Destroy(battery);
        }
    }
}
