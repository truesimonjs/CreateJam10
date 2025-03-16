using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.AI;

public class JohnController : MonoBehaviour
{
    GameObject player;
    bool attacking = false;
    [SerializeField] private float attackCooldown, damage, attackDistance;
    public Transform target;
    public NavMeshAgent agent;
    
    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    
    private void Update()
    {
        agent.destination = target.position;

        if (Vector2.Distance(transform.position, player.transform.position) < attackDistance && !attacking)
        {
            attacking = true;
            StartCoroutine(Attacking());
        }
        
    }

    private IEnumerator Attacking()
    {
        attacking = true;
        yield return new WaitForSeconds(attackCooldown);
        player.GetComponent<IDamageable>().DamageDeduction(damage);
        attacking = false;
    }
}
