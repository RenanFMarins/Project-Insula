using UnityEngine;
using UnityEngine.AI;

public class SpiderAI : MonoBehaviour
{
    public Transform target;
    public float detectionRange = 10f;
    public float attackRange = 2f;

    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
    	
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
	{
	    if (target == null) return;

	    float distance = Vector3.Distance(transform.position, target.position);
	    float speed = agent.desiredVelocity.magnitude;

	    if (distance <= detectionRange)
	    {
		agent.SetDestination(target.position);
		animator.SetFloat("Speed", speed);

		if (distance <= attackRange)
		{
		    agent.isStopped = true;
		    animator.SetBool("IsAttacking", true);
		}
		else
		{
		    agent.isStopped = false;
		    animator.SetBool("IsAttacking", false);
		}
	    }
	    else
	    {
		animator.SetFloat("Speed", 0f);
		animator.SetBool("IsAttacking", false);
		agent.isStopped = true;
	    }
	}

    void Attack()
    {
        // Aqui você pode adicionar lógica de dano ou efeito
        Debug.Log("Aranha atacando com animação!");
    }
}

