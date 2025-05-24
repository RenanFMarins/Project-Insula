using UnityEngine;
using UnityEngine.AI;

public class SpiderAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        // Persegue se estiver longe
        if (distance > attackRange)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.ResetPath();

            // Ataca se tempo de recarga passou
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
	{
	    Debug.Log("Aranha atacou!");

	    // Reproduz a animação de ataque (legacy)
	    Animation anim = GetComponent<Animation>();
	    if (anim != null && anim["attack1"] != null)
	    {
		anim.Play("attack1");
	    }

	    // Aplica dano ao alvo, se desejar
	    float distance = Vector3.Distance(transform.position, target.position);
	    if (distance <= attackRange)
	    {
		target.SendMessage("TakeDamage", 10f, SendMessageOptions.DontRequireReceiver);
	    }
	}
}

