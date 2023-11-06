using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{

    public GameObject light;
    private bool isLightOn = true;
    public Text text;
    public float percent = 100.0f;
    public float batteries = 0.0f;
    public AudioSource on;
    public AudioSource off;

    void Update()
    {
        text.text = percent.ToString("0") + "%";
        if (Input.GetKeyDown("f"))
        {
            isLightOn = !isLightOn;
            light.SetActive(isLightOn);
            if (isLightOn)
                on.Play(); 
            else if (!isLightOn)
                off.Play();
        }
        
        // Decrement the battery
        if (isLightOn) { percent -= 0.5f * Time.deltaTime; }

        // Make sure it doesn't go over 100%
        if (percent >= 100) { percent = 100; }

        // Make sure it doesn't go over 0%
        if (percent <= 0)
        {
            light.SetActive(false);
            percent = 0;
        }
    }

    public void IncreaseBattery() { percent += 25; }
}
