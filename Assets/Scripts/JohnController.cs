using System.Collections;
using Player;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.LowLevelPhysics;

public class JohnController : MonoBehaviour
{
    GameObject player;
    bool attacking = false;
    [SerializeField] private float attackCooldown, damage, attackDistance;
    public Transform target;
    public NavMeshAgent agent;
    [SerializeField]private Animator animator;
    bool isFacingRight = true;
    public RageBar ragebar;
    
    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.Find("Triangle");
    }
    
    private void Update()
    {
        agent.destination = target.position;
        if (agent.velocity.magnitude > 0 )
        {
            animator.SetBool("IsMoving",true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        if (Vector2.Distance(transform.position, player.transform.position) < attackDistance && !attacking)
        {
            attacking = true;
            animator.SetTrigger("Attack");
            StartCoroutine(Attacking());
        }
        Flip();
    }
    private void Flip()
    {
        if (isFacingRight && agent.velocity.x < 0f || !isFacingRight && agent.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator Attacking()
    {
        attacking = true;
        player.GetComponent<IDamageable>().DamageDeduction(damage);
        ragebar.SubtractFromRageSlider(5);
        yield return new WaitForSeconds(attackCooldown);
        attacking = false;
    }
}
