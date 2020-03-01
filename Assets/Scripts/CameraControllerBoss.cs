using UnityEngine;
using System.Collections;
using System;

public class CameraControllerBoss : MonoBehaviour
{
    public GameObject player;
    private Vector2 prevPlayerPosition;
    private Vector2 playerPosition;
    private float cameraZoom;
    private float maxZoom = 143f;
    private float minZoom = 116f;
    void Start()
    {
        //playerPosition = player.transform.position;
    }
    void Update()
    {
        playerPosition = player.transform.position;
        cameraZoom = Math.Abs(playerPosition.x - 100);
        if (cameraZoom < minZoom)
            cameraZoom = minZoom;
        else if (cameraZoom > maxZoom)
            cameraZoom = maxZoom;
        GetComponent<UnityEngine.Camera>().fieldOfView = cameraZoom;
    }
}