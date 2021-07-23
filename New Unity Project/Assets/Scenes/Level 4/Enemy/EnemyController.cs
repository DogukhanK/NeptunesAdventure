using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10.0f;

    Transform player;
    NavMeshAgent enemy;

    void Start()
    {
        player = PlayerInstance.instance.player.transform;
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= lookRadius)
        {
            enemy.SetDestination(player.position);

            if (dist <= enemy.stoppingDistance)
            {

            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position = transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }
}
