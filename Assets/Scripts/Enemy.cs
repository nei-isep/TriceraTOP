using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour {
    private AIPath path;
    private Vector3 scale;
    void Start() {
        scale = GetComponent<Transform>().localScale;
    }
    void Update() {
        path = GetComponent<AIPath>();

        if (path.desiredVelocity.x >= 0.01f)
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);

        else if (path.desiredVelocity.x <= -0.01f)
            transform.localScale = scale;
    }

    public void Die() {
        Destroy(gameObject);
    }

    // Collision
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            Player player = col.gameObject.GetComponent<Player>();

            player.takeDamage();
        }
    }
}
