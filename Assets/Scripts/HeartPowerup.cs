using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerup : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player") {
            Player player = hitInfo.GetComponent<Player>();
            
            if (player.health < 3) {
                player.HealthUp();
                Player.score++;

                Destroy(gameObject);
            }
        }
    }
}
