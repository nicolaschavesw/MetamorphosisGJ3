using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public Transform player; 
    public Enemy enemy;
    public string playerTag = "Player";
    private float minDistance = 5f;
    private NavMeshAgent agent; 
    private Animator animator;
    private bool isWalking = false;
    private bool isInRange = false;
    private float detectionAngle = 60f;
    private float detectionRange = 10f;
    private float attackRange = 1.5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer < minDistance)
        {
            animator.SetBool("isReacting", true);
            StartCoroutine(ReactForSeconds(2f));

            if(!enemy.isDead)
            {
                agent.SetDestination(player.position);

                if (distanceToPlayer < attackRange)
                {
                    AttackPlayer();
                }
            }  
            else
            {
                player.position = player.position;
                animator.SetBool("isDead", true);
            }
        }

        ChangeMovement();
    }

    public void AttackPlayer()
    {
        Player playerScript = player.GetComponent<Player>();
        playerScript.TakeDamage(1);
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
        }
        else
        {
            isInRange = false;
        }
    }
    public IEnumerator ReactForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("isReacting", false);
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
