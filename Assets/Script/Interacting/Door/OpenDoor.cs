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
        rotSpeed = 1.5f;
        doorBool = false; 
    }

	void Update()
	{
        if (doorBool)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(OpenRotation), rotSpeed * Time.deltaTime);
        else if (!doorBool)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(CloseRotation), rotSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == "Door_Room_Entry_LOD (3)")
        {
            if(other.gameObject.name == "Character")
            {
                DialogueManager.Instance.StartDialogue(3, 8);
            }
        }
    }

	public void InteractWithDoor() { doorBool = !doorBool; }

}

