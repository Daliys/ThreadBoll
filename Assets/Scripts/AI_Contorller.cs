using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AI_Contorller : MonoBehaviour
{

    // ты хотел разбросать по карте рандомно точки и боты будут брать рандомную точку из кучи и идти туда ( даст небольной рандом)

    public Vector3 target;
    public Material coloringMaterial;
    public AIPath aiPath;
    private int currentStage;
    private NavMeshAgent navMeshAgent;


    void Start()
    {
        currentStage = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        //  navMeshAgent.Move(target.transform.position);
        target = aiPath.GetRandomPosition(currentStage);
        navMeshAgent.SetDestination(aiPath.GetRandomPosition(currentStage));
       //navMeshAgent.
       
  //      navMeshAgent.updateRotation = false;

    }

    // Update is called once per framef
    void Update()
    {

        NavMeshPath path = navMeshAgent.path;
        if(Input.GetKeyDown(KeyCode.O))
        foreach (var f in path.corners) { print("Path : " + f); }

        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance <= 1f)
        {
            if (aiPath.GetLength() > (currentStage + 1))
            {
                currentStage++;
                navMeshAgent.SetDestination(aiPath.GetRandomPosition(currentStage));
                target = aiPath.GetRandomPosition(currentStage);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Yarn")
        {
            YarnInformation info = other.GetComponent<YarnInformation>();
            if (info.isClear)
            {
                other.gameObject.GetComponent<MeshRenderer>().material = coloringMaterial;
                info.isClear = false;
                transform.localScale += Vector3.one * (info.AddedSize / 5);
                Destroy(other.gameObject, 0.02f);
            }
        }

    }

}
