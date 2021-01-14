using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AI_Contorller : MonoBehaviour
{

    public GameObject target;
    private NavMeshAgent navMeshAgent;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
      //  navMeshAgent.Move(target.transform.position);
        navMeshAgent.destination = target.transform.position;
        
  //      navMeshAgent.updateRotation = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       // navMeshAgent.velocity = Vector3.forward * 5;
    }
}
