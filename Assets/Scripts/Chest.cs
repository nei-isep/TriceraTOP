using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    public Animator chestAnimator;

    public Transform spawnPoint;

    // Possible spawns prefabs
    public GameObject enemy;
    public GameObject heart;
    public GameObject blueFire;

    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag == "Player" && !chestAnimator.GetBool("open")) {
            chestAnimator.SetBool("open", true);

            int spawn = Random.Range(0, 3);

            switch (spawn) {
                case 0:
                    Instantiate(enemy, spawnPoint.position + new Vector3(4, -3, 0), spawnPoint.rotation);
                    break;
                case 1:
                    Instantiate(heart, spawnPoint.position, spawnPoint.rotation);
                    break;
                case 2:
                    Instantiate(blueFire, spawnPoint.position, spawnPoint.rotation);
                    break;
            }
        }
    }
}
