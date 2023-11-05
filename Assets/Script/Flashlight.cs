using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour
{
    /*
    private Vector3 vector;
    public float speed = 5.0f;
    public GameObject gameObject;
    */
    public GameObject light;
    private bool isLightOn = true;
    public Light light2;
    public TMP_Text text;

    public TMP_Text batteryText;

    public float lifetime = 100;

    public float batteries = 0;

    public AudioSource flashON;
    public AudioSource flashOFF;

    private bool on;
    private bool off;

    // Start is called before the first frame update
    void Start()
    {
        /*
        gameObject = Camera.main.gameObject;
        // Getting the offset of the postion
        vector = transform.position - gameObject.transform.position;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.position = gameObject.transform.position + vector;
        transform.rotation = Quaternion.Slerp(transform.rotation, gameObject.transform.rotation, speed * Time.deltaTime);
        */
        if (Input.GetKeyDown("f"))
        {
            isLightOn = !isLightOn;
            light.SetActive(isLightOn);
        }
        
    }
}
