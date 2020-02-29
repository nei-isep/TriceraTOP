using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool triggerAttackAnimation;
    public float attackAnimationDelay;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            triggerAttackAnimation = true;
            StartCoroutine("FireDelay");
        }
    }

    void Shoot() {
        if (GetComponent<Player>().health != 0)
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    public bool getAttackTrigger()
    {
        return triggerAttackAnimation;
    }

    public IEnumerator FireDelay() {
        yield return new WaitForSeconds(attackAnimationDelay);

        triggerAttackAnimation = false;
    }
}
    