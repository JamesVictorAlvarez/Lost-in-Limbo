using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintSlider : MonoBehaviour
{
    public Slider slider;
    private FirstPersonController script;

    void Start()
    {
        script = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        slider.value = script.sprintTimer;
    }
}
