using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float offset;
    internal float farClipPlane;

    public float NearClipPlane { get; internal set; }

    void Update()
    {
        transform.position = new Vector2 (player.transform.position.x, player.transform.position.y + offset);
    }
}
