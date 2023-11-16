using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    private bool isOpen;
    private Vector3 OpenPosition, ClosePostion;
    private float moveSpeed;

    void Start()
    {
        OpenPosition = transform.position + new Vector3(-0.7f, 0,0);
        ClosePostion = transform.position;
        moveSpeed = 1.5f;
        isOpen = false;
    }

    void Update()
    {
        if (isOpen)
            transform.position = Vector3.Lerp(transform.position, OpenPosition, moveSpeed * Time.deltaTime);
        else if (!isOpen)
            transform.position = Vector3.Lerp(transform.position, ClosePostion, moveSpeed * Time.deltaTime);
    }

    public void InteractWithDrawer() { isOpen = !isOpen; }
}
