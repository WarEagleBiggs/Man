using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Man : MonoBehaviour
{
    //ref to actual ai agent
    public NavMeshAgent agent;
    
    //circular range from ai
    public float range;

    public Transform PlayerPos;
    public bool isChase;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isChase == false)
        {
            Wander();
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance < 0.1f && isChase == false)
        {
            Wander();
        }
        agent.SetDestination(PlayerPos.position);
    }

    public void Wander()
    {
        
        //random spot to move to
        agent.isStopped = false;
        
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        
        if (NavMesh.SamplePosition(randomDirection, out hit, range, 1))
        {
            finalPosition = hit.position;
        }

        agent.SetDestination(finalPosition);
    }
}
