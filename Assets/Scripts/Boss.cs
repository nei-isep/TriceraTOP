using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    //Movement
    private Rigidbody2D rigidBody;
    public Player player;
    public static int frameDelay = 10;
    private Vector2[] movements = new Vector2[frameDelay];
    private bool[] facingRight = new bool[frameDelay];
    private int counter = 0;

    public int health;

    //Animation
    private Animator bossAnimation;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    private bool isTouchingGround;
    private Weapon weaponScript;

    // Start is called before the first frame update
    void Start() {
        health = Player.score;
        rigidBody = GetComponent<Rigidbody2D>();
        bossAnimation = GetComponent<Animator>();
        weaponScript = GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update() {
        // Good ending
        if (Player.score == 0) {
            SceneManager.LoadScene(7);
        }

        // Bad ending
        else if (health <= 0) {
            SceneManager.LoadScene(6);
        }

        //Mirrored movement with delay
        else {
            if (counter < frameDelay) {
                movements[counter] = new Vector2(-player.GetVelocity().x, player.GetVelocity().y);
                rigidBody.velocity = new Vector2(0, 0);
                facingRight[counter] = player.GetDirection();
                counter++;
            }

            else {
                rigidBody.velocity = movements[0];

                if (facingRight[0] != facingRight[1])
                    transform.Rotate(0f, 180f, 0f);

                for (int i = 1; i < movements.Length; i++) {
                    movements[i - 1] = movements[i];
                    facingRight[i - 1] = facingRight[i];
                }

                movements[movements.Length - 1] = new Vector2(-player.GetVelocity().x, player.GetVelocity().y);
                facingRight[facingRight.Length - 1] = player.GetDirection();
            }
        }

        //Animation
        bossAnimation.SetFloat("Speed", Math.Abs(rigidBody.velocity.x));

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        bossAnimation.SetBool("isTouchingGround", isTouchingGround);

        bossAnimation.SetBool("triggerAttack", weaponScript.getAttackTrigger());

        bossAnimation.SetFloat("Health", health);

    }

    public void takeDamage() {
        health--;
    }
}

