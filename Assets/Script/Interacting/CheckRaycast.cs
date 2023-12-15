using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class CheckRaycast : MonoBehaviour
{
    public float maxDistance = 1.7f;
    public LayerMask layer;
    public GameObject cabinetText, drawerText, lampText, batteryText, flashlight, keyText, lockText, doorText;
    private GameObject cabinet, drawer, lamp, battery, key, lockDoor;
    private bool inRange;
    private bool hasKey = false;
    private OpenCabinet cabinetScript;
    private OpenDrawer drawerScript;
    private Light lampLight;
    private Flashlight flashlightScript;
    private bool isOn;

    void Start()
    {
        cabinetText.SetActive(false);
        drawerText.SetActive(false);
        lampText.SetActive(false);
        batteryText.SetActive(false);
        keyText.SetActive(false);
    }

    void Update()
    {
        CheckObject();
        Interact();
    }

    public void CheckObject()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Check if the object hit by the raycast is a cabinet.
            if (hit.collider.CompareTag("Cabinet"))
            {
                inRange = true;
                cabinetText.SetActive(true);
                GameObject newCabinet = hit.collider.gameObject;
                if (newCabinet != cabinet)
                {
                    // If a new cabinet is detected, store it.
                    cabinet = newCabinet;
                }
                drawer = lamp = battery = lockDoor = null;
                drawerText.SetActive(false);
                lampText.SetActive(false);
                batteryText.SetActive(false);
            }

            // Check if the object hit by the raycast is a drawer.
            if (hit.collider.CompareTag("Drawer"))
            {
                inRange = true;
                drawerText.SetActive(true);
                GameObject newDrawer = hit.collider.gameObject;
                if (newDrawer != drawer)
                {
                    // If a new drawer is detected, store it.
                    drawer = newDrawer;
                }
                cabinet = lamp = battery = lockDoor = key = null;
                cabinetText.SetActive(false);
                lampText.SetActive(false);
                batteryText.SetActive(false);
                keyText.SetActive(false);
            }

            // Check if the object hit by the raycast is a lamp.
            if (hit.collider.CompareTag("Lamp"))
            {
                inRange = true;
                lampText.SetActive(true);
                GameObject newLamp = hit.collider.gameObject;
                if (newLamp != lamp)
                {
                    // If a new lamp is detected, store it.
                    lamp = newLamp;
                }
                cabinet = drawer = battery = lockDoor = null;
                cabinetText.SetActive(false);
                drawerText.SetActive(false);
                batteryText.SetActive(false);
            }

            // Check if the object hit by the raycast is the battery.
            if (hit.collider.CompareTag("Battery"))
            {
                inRange = true;
                batteryText.SetActive(true);
                GameObject newBattery = hit.collider.gameObject;
                if (newBattery != battery)
                {
                    // If a new battery is detected, store it.
                    battery = newBattery;
                }
                cabinet = drawer = lamp = lockDoor = null;
                cabinetText.SetActive(false);
                drawerText.SetActive(false);
                lampText.SetActive(false);
            }

            // Check if the object hit by the raycast is the key.
            if (hit.collider.CompareTag("Key"))
            {
                inRange = true;
                keyText.SetActive(true);
                key = hit.collider.gameObject;
                cabinet = drawer = lamp = lockDoor = null;
                cabinetText.SetActive(false);
                drawerText.SetActive(false);
                lampText.SetActive(false);
            }

            if (hit.collider.CompareTag("NextLevel") && !hasKey)
            {
                inRange = true;
                lockText.SetActive(true);
                lockDoor = hit.collider.gameObject;
                cabinet = drawer = lamp = null;
                cabinetText.SetActive(false);
                drawerText.SetActive(false);
                lampText.SetActive(false);
            }

            if (hit.collider.CompareTag("NextLevel") && hasKey)
            {
                inRange = true;
                doorText.SetActive(true);
                lockDoor = hit.collider.gameObject;
                cabinet = drawer = lamp = null;
                cabinetText.SetActive(false);
                drawerText.SetActive(false);
                lampText.SetActive(false);
            }
        }
        else
        {
            cabinet = drawer = lamp = battery = lockDoor = key = null;
            inRange = false;
            cabinetText.SetActive(false);
            drawerText.SetActive(false);
            lampText.SetActive(false);
            batteryText.SetActive(false);
            keyText.SetActive(false);
            lockText.SetActive(false);
        }
    }

    public void Interact()
    {
        if (Input.GetButtonDown("Interact") && inRange)
        {
            if (cabinet != null)
            {
                cabinetScript = cabinet.GetComponent<OpenCabinet>();
                cabinetScript.InteractWithCabinet();
            }
            if (drawer != null)
            {
                drawerScript = drawer.GetComponent<OpenDrawer>();
                drawerScript.InteractWithDrawer();
            }
            if (lamp != null)
            {
                isOn = !isOn;
                lampLight = lamp.transform.Find("Light").GetComponent<Light>();
                if (isOn)
                    lampLight.enabled = true;
                else lampLight.enabled = false;
            }
            if (battery != null)
            {
                flashlightScript = flashlight.GetComponent<Flashlight>();
                flashlightScript.IncreaseBattery();
                Destroy(battery);
            }
            if (key != null)
            {
                hasKey = true;
                Destroy(key);
            }
            if (lockDoor != null && hasKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
