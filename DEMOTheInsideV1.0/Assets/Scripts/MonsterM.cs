using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

public class MonsterM : MonoBehaviour
{
    private GameObject objective;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        objective = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

       
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(objective.transform.position);
    }
}
