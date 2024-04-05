using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    private float minDistance = 5f;
    private NavMeshAgent agent; 
    private Animator animator;
    private bool isWalking = false;
    private bool isInRange = false;
    private float detectionAngle = 60f;
    private float detectionRange = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer < minDistance)
        {
          agent.SetDestination(player.position);  
        }

        ChangeMovement();
    }

    void ChangeMovement()
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            if (!isWalking)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isReacting", false);
                isWalking = true;
            }
        }
        else
        {
            if (isWalking)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isReacting", false);
                isWalking = false;
            }
        }


        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        float distanceToPlayer = directionToPlayer.magnitude;

        if (angle < detectionAngle / 2 && distanceToPlayer < detectionRange)
        {
            isInRange = true;
            animator.SetBool("isReacting", true);
        }
        else
        {
            isInRange = false;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Vector3 rightLimit = Quaternion.Euler(0, detectionAngle / 3, 0) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + rightLimit * detectionRange);

        Vector3 leftLimit = Quaternion.Euler(0, -detectionAngle / 3, 0) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + leftLimit * detectionRange);
    }
}

