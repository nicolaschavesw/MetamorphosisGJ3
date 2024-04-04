using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    public float minDistance = 5f;
    private NavMeshAgent agent; 
    private Animator animator;
    private bool isWalking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer > minDistance)
        {
          agent.SetDestination(player.position);  
        }

        ChangeMovement();
    }

    void ChangeMovement()
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            // Cambiar a la animación de caminar si el agente está caminando
            if (!isWalking)
            {
                animator.SetBool("isWalking", true);
                isWalking = true;
            }
        }
        else
        {
            // Cambiar a la animación de inactividad si el agente no está caminando
            if (isWalking)
            {
                animator.SetBool("isWalking", false);
                isWalking = false;
            }
        }
    }
}
