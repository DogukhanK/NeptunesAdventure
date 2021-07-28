using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float chaseSpeed = 30.0f;
    public float playerDist;

    private int damage = 0;

    public Transform target;
    

    Animator anim;
    NavMeshAgent nav;

    PlayerMovement player;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        playerDist = Vector3.Distance(target.transform.position, transform.position);

        anim.SetFloat("playerDist", playerDist);

        if (damage > 0)
        {
            float health = anim.GetFloat("health");
            health -= damage;
            damage = 0;
            if (health < 0)
            {
                health = 0;
            }
            anim.SetFloat("health", health);
        }

        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

        if (state.IsName("attack"))
        {
            nav.SetDestination(target.position);
        }

        if (state.IsName("chase"))
        {
            nav.SetDestination(target.position);
        }

        if (anim.IsInTransition(0) && anim.GetNextAnimatorStateInfo(0).IsName("chase"))
        {
            nav.isStopped = false;
            nav.speed = chaseSpeed;
            nav.SetDestination(target.position);
        }

        if (anim.IsInTransition(0) && anim.GetNextAnimatorStateInfo(0).IsName("idle"))
        {
            nav.isStopped = true;
        }

        if (anim.IsInTransition(0) && anim.GetNextAnimatorStateInfo(0).IsName("attack"))
        {
            nav.isStopped = false;
        }
    }

    public void Attack()
    {
        Rotating.isTrigger = true;
    }

}
