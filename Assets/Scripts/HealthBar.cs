using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public Boss boss;
    float initial_health;

    // Start is called before the first frame update
    void Start() {
        initial_health = boss.health;
    }

    // Update is called once per frame
    void Update() {
        Transform bar = transform.Find("Bar");
        if (initial_health != 0)
            bar.localScale = new Vector3(boss.health / initial_health, 1f);
        else
            bar.localScale = new Vector3(0, 1f);
    }
}
