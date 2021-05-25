using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Transform target;

    public AggroDetection aggroDetection { get; private set; }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        this.target = target;

    }

    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);

            float currentSpeeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeeed);
        }
    }
}
