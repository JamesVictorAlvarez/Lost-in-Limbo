using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1.0f, 1.0f)]
    private float offset;
    public float scrollSpeed = 0.5f;

    private Renderer renderer;
    private Vector2 savedOffset;

    void Start () {
        renderer = GetComponent<Renderer> ();
    }

    void Update () {
        offset += (Time.deltaTime * scrollSpeed) / 10.0f;
        renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2 (offset, 0));
    }
}
