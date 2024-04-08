using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCrabController : MonoBehaviour
{
    public Transform player;
    public Enemy enemy;
    private float minDistance = 5f;
    private NavMeshAgent agent;
    private Animation animacion;

    public AnimationClip standAnimation;
    public AnimationClip fightStandAnimation;
    public AnimationClip walkAnimation;
    public AnimationClip deadEndAnimation;

    private bool isInRange = false;
    private float detectionAngle = 60f;
    private float detectionRange = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animacion = GetComponent<Animation>();

        // Asigna las animaciones desde el componente Animation
        if (animacion != null)
        {
            animacion[standAnimation.name].wrapMode = WrapMode.Loop;
            animacion[fightStandAnimation.name].wrapMode = WrapMode.Loop;
            animacion[walkAnimation.name].wrapMode = WrapMode.Loop;
            animacion[deadEndAnimation.name].wrapMode = WrapMode.Once;
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < minDistance)
        {
            if (!enemy.isDead)
            {
                // El jugador está cerca, activa la animación de combate
                PlayAnimation(fightStandAnimation);
                agent.SetDestination(player.position);
            }
            else
            {
                // El enemigo está muerto, activa la animación de muerte
                PlayAnimation(deadEndAnimation);
            }
        }
        else
        {
            // El jugador no está cerca, activa la animación de caminar o la animación de reposo
            if (agent.velocity.magnitude > 0.1f)
            {
                // El enemigo está caminando, activa la animación de caminar
                PlayAnimation(walkAnimation);
            }
            else
            {
                // El enemigo está en reposo, activa la animación de reposo
                PlayAnimation(standAnimation);
            }
        }
    }

    void PlayAnimation(AnimationClip animationClip)
    {
        if (animacion != null)
        {
            // Reproduce la animación específica
            animacion.Play(animationClip.name);
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
