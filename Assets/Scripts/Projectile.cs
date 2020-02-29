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
        if (hitInfo.gameObject.tag == "Enemy") {
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            enemy.Die();
            Score.value++;
        }

        Destroy(gameObject);
    }
}