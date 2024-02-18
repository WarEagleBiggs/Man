using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Man : MonoBehaviour
{
    //ref to actual ai agent
    public NavMeshAgent agent;
    
    //circular range from ai
    public float range;

    public Transform PlayerPos;
    public bool isChase;

    public Master MasterScript;
    
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
        if (isChase)
        {
            agent.SetDestination(PlayerPos.position);
        }
        if(agent.remainingDistance < 0.1f)
        {
            int randomNum = Random.Range(0, 2);
            if (randomNum == 0)
            {
                StartCoroutine(Chase());
            }
            else
            {
                Wander();
            }
            
        }
        
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

    public IEnumerator Chase()
    {
        isChase = true;
        yield return new WaitForSeconds(Random.Range(2,30));
        isChase = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Manhole")
        {
            //Teleport
            int ran = Random.Range(0, MasterScript.Manholes.Count);
            gameObject.transform.position = MasterScript.Manholes[ran].gameObject.transform.position;
        } else if (other.tag == "Player")
        {
            SimplePlayerController con = other.GetComponent<SimplePlayerController>();
            con.Health = con.Health - 25;
        }
    }
}
