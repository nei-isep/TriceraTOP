using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject boss;
    private Vector3 playerRespawnPoint;
    private Vector3 bossRespawnPoint;
    private bool respawnBoss;
    public float respawnDelay;

    // Start is called before the first frame update
    void Start() {
        playerRespawnPoint = player.transform.position;
        if (SceneManager.GetActiveScene().name == "Boss")
        {
            bossRespawnPoint = boss.transform.position;
            respawnBoss = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player")
            StartCoroutine("RespawnDelay");
    }

    private IEnumerator RespawnDelay() {
        yield return new WaitForSeconds(respawnDelay);

        player.transform.position = playerRespawnPoint;
        if (respawnBoss)
            boss.transform.position = bossRespawnPoint;
        player.GetComponent<Player>().takeDamage();
    }
}
