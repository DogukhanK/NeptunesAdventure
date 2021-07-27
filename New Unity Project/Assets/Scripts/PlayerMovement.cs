using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // can access in inspector
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float doubleJump = 0.5f;

    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDist;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpHeight;

    private CharacterController controller;
    private Animator anim;
    private Rigidbody rb;

    public AudioSource jumpAudio;
    public AudioSource runAudio;
    public AudioSource attackAudio;
    public AudioSource deathAudio;

    private bool isRunning = false;
    private bool jumpCooldown = false;
    private bool attackCooldown = false;
    private bool canDoubleJump = false;
    private bool isMoveJump = false; // Does the player want to move when jumping?

    public int maxHealth = 100;
    public int health;

    public HealthBar healthBar;
    public HealthBar1 healthBar1;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar1.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (Rotating.isTrigger == true)
        {
            TakeDamage(20);
            Rotating.isTrigger = false;
        }

        if (health <= 0)
        {
            Death.isDead = true;
            deathAudio.Play();
        }
    }

    void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDist, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        // Make the player move when jumping
        if (isMoveJump && !isGrounded)
        {
            moveDirection = new Vector3(0, 0, 1);
            moveDirection = transform.TransformDirection(moveDirection);

            Walk();

            moveDirection *= moveSpeed;
        }

        if (isGrounded)
        {
            canDoubleJump = true;

            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
            {
                DoubleJump();
                canDoubleJump = false;
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isRunning)
        {
            if (!runAudio.isPlaying)
            {
                runAudio.Play();
            }
        }
        else
            runAudio.Stop();

        if (jumpAudio.isPlaying)
        {
            runAudio.Stop();
        }
        if (attackAudio.isPlaying)
        {
            runAudio.Stop();
        }
    }

    void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
        isRunning = false;
    }

    void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
        isRunning = true;
    }

    void Jump()
    {
        if (jumpCooldown == false)
        {
            // Does the player want to move when jumping forward?
            if (Input.GetAxis("Vertical") > 0.0f)
                isMoveJump = true;
            else
                isMoveJump = false;

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpAudio.Play();
        }
    }

    void DoubleJump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity * doubleJump);
        jumpAudio.Play();
        //Invoke("ResetJumpCooldown", 2.1f);   // add short delay which is slightly longer than the animation to prevent buttom spam
        //jumpCooldown = true;
    }

    void Attack()
    {
        if (attackCooldown == false)
        {
            anim.SetTrigger("Attack");
            attackAudio.Play();
            Invoke("ResetAttackCooldown", 1.2f);
            attackCooldown = true;
        }
    }

    void ResetJumpCooldown()
    {
        jumpCooldown = false;
    }
    void ResetAttackCooldown()
    {
        attackCooldown = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetHealth(health);
        healthBar1.SetHealth(health);
    }
}