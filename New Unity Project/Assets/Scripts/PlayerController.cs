using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    CapsuleCollider col;

    public float speed = 5.0f;
    public float rotationSpeed = 250.0f;
    //public float jumpPower = 3.0f;

    public AudioSource jumpAudio;
    public AudioSource runAudio;
    public AudioSource attackAudio;

    private bool isRunning = false;
    private bool jumpCooldown = false;
    private bool attackCooldown = false;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        Cursor.visible = false;
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Rotate(0, rotation, 0);

        if (translation !=0)
        {
            anim.SetBool("isMoving", true);
            isRunning = true;
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        anim.SetFloat("MoveSpeed", translation);
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (attackCooldown == false)
            {
                anim.SetTrigger("Attack");
                attackAudio.Play();
                Invoke("ResetAttackCooldown", 0.9f);
                attackCooldown = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCooldown == false)
            {
                anim.SetTrigger("Jump");
                //rb.AddForce (Vector3.up * jumpPower, ForceMode.VelocityChange);
                jumpAudio.Play();
                Invoke("ResetJumpCooldown", 2.1f);   // add short delay which is slightly longer than the animation to prevent buttom spam
                jumpCooldown = true;
            }
        }

        if (translation==0)
        {
            isRunning = false;
        }

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

    public void FootL()
    {

    }
    public void FootR()
    { 

    }
    public void Hit()
    {

    }

    void ResetJumpCooldown()
    {
        jumpCooldown = false;
    }
    void ResetAttackCooldown()
    {
        attackCooldown = false;
    }
}
