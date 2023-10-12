using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Vector3 vector;
    public float speed = 5.0f;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject = Camera.main.gameObject;
        // Getting the offset of the postion
        vector = transform.position - gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gameObject.transform.position + vector;
        transform.rotation = Quaternion.Slerp(transform.rotation, gameObject.transform.rotation, speed * Time.deltaTime);
    }
}
