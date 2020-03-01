using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFirePowerup : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player") {
            Player player = hitInfo.GetComponent<Player>();

            player.hasBlueFire = true;

            Destroy(gameObject);  
        }
    }
}
