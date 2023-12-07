using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinet : MonoBehaviour
{
    private bool isOpen;
    public Vector3 OpenRotation, CloseRotation;
    private float rotSpeed;


    void Start()
    {
        rotSpeed = 1.5f;
        isOpen = false;
    }

    void Update()
    {
        if (isOpen)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(OpenRotation), rotSpeed * Time.deltaTime);
        else if (!isOpen)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CloseRotation), rotSpeed * Time.deltaTime);
    }

    public void InteractWithCabinet() { isOpen = !isOpen; }
}
