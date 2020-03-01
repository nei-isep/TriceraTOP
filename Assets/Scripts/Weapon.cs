using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    private bool triggerAttackAnimation;
    public float attackAnimationDelay;
    public AudioSource audioData1;
    public AudioSource audioData2;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot(1);
            triggerAttackAnimation = true;
            StartCoroutine("FireDelay");
        }

        else if (Input.GetButtonDown("Fire2")) {
            Shoot(2);
            triggerAttackAnimation = true;
            StartCoroutine("FireDelay");
        }
    }

    void Shoot(int bullet) {
        if (GameObject.Find("Player").GetComponent<Player>().health != 0)
            switch (bullet) {
                case 1:
                    Instantiate(bulletPrefab1, firePoint.position, firePoint.rotation);
                    audioData1.Play(0);
                    break;
                case 2:
                    if (GameObject.Find("Player").GetComponent<Player>().hasBlueFire) {
                        Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
                        GameObject.Find("Player").GetComponent<Player>().hasBlueFire = false;
                        audioData2.Play(0);
                    }

                    break;
            }
    }

    public bool getAttackTrigger() {
        return triggerAttackAnimation;
    }

    public IEnumerator FireDelay() {
        yield return new WaitForSeconds(attackAnimationDelay);

        triggerAttackAnimation = false;
    }
}
    