using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    //Movement
    private Rigidbody2D rigidBody;
    public float speed;
    public float jumpSpeed;
    private float movement;
    public float groundCheckRadius;
    public Transform groundCheckPoint;
    private bool isTouchingGround;
    public LayerMask groundLayer;
    public bool isFacingRight = false;
    public int health = 3;

    const float blinkingDelay = 0.1f;

    //Animation
    private Animator playerAnimation;
    private Weapon weaponScript;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        weaponScript = GetComponent<Weapon>();

        // Hide mouse cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        // Player died
        if (health == 0) {
            movement = 0;
            jumpSpeed = 0;

            StartCoroutine("DelayFade");

        }

        else
            movement = Input.GetAxis("Horizontal");

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isTouchingGround)
            rigidBody.velocity = new Vector2(movement * speed, jumpSpeed);

        else
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);

        if (movement > 0f && !isFacingRight) {
            isFacingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }

        else if (movement < 0f && isFacingRight) {
            isFacingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }

        if (health == 0)
            movement = 0;

        //Animation
        playerAnimation.SetFloat("Speed", Math.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("isTouchingGround", isTouchingGround);
        playerAnimation.SetBool("triggerAttack", weaponScript.getAttackTrigger());
        playerAnimation.SetFloat("Health", health);
    }

    // Player is damaged
    public void takeDamage() {
        health--;

        SpriteBlinkingEffect();

        GameObject Heart = GameObject.Find("Heart" + health.ToString());
        Destroy(Heart);
    }

    private void SpriteBlinkingEffect() {
        GetComponent<SpriteRenderer>().color = Color.red;

        StartCoroutine("BlinkingEffectDelay");
    }

    private IEnumerator BlinkingEffectDelay() {
        yield return new WaitForSeconds(blinkingDelay);

        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator DelayFade() {
        yield return new WaitForSeconds(2.0f);
        
        GameObject.Find("Canvas").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(1);
    }
}
