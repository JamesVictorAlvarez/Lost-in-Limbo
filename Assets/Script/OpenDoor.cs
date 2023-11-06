using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour 
{
	public Vector3 OpenRotation, CloseRotation;
    private float rotSpeed;
	public bool doorBool;

    void Start() 
    {
        rotSpeed = 3.0f;
        doorBool = false; 
    }

	void Update()
	{
        if (doorBool)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(OpenRotation), rotSpeed * Time.deltaTime);
        else if (!doorBool)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CloseRotation), rotSpeed * Time.deltaTime);
    }

	public void InteractWithDoor() { doorBool = !doorBool; }

}

