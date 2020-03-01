using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerNormal : MonoBehaviour
{
    public GameObject player;
    public float offset;
    private Vector3 playerPosition;
    public float offsetSmoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.rotation.y == -1)
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        else
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        Debug.Log(player.transform.rotation.y);
    }
}
