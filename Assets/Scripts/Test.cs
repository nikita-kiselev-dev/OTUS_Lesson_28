using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Goal;
    
    void Update()
    {
        Agent.destination = Goal.position;
    }
}
