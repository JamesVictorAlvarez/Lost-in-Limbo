using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    float timeOn = 0.1f;
    float timeOff = 0.5f;
    private float changeTime = 0.0f;
    private Light light;
    private float lightLevel;

    void Start()
    {
        light = GetComponent<Light>();
        lightLevel = light.intensity;

        InvokeRepeating("Flicker", 0.0f, 1.0f);
    }

    void Flicker()
    {
        float randomNum = Random.Range(0.0f, 2.5f);

        light.intensity = lightLevel * randomNum;
    }

}
