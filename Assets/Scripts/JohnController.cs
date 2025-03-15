using UnityEngine;
using UnityEngine.AI;

public class JohnController : MonoBehaviour
{
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
    }
}
