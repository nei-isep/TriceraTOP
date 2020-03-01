using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start() {
        rb.velocity = transform.right * -speed;
    }

    // Collision
    void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.gameObject.tag != "Barrier") {
            if (hitInfo.gameObject.tag == "Enemy") {
                Enemy enemy = hitInfo.GetComponent<Enemy>();

                enemy.Die();
                Player.score++;

                if (gameObject.name == "BlueFire(Clone)")
                    return;
            }

            if (hitInfo.gameObject.tag == "Boss") {
                Boss boss = hitInfo.GetComponent<Boss>();

                boss.takeDamage();

                if (gameObject.name == "BlueFire(Clone)")
                    boss.takeDamage(); // Double damage
            }

            if (hitInfo.gameObject.tag == "Player") {
                Player player = hitInfo.GetComponent<Player>();

                player.takeDamage();

                if (gameObject.name == "BlueFire(Clone)")
                    player.takeDamage(); // Double damage
            }

            Destroy(gameObject);
        }
    }
}