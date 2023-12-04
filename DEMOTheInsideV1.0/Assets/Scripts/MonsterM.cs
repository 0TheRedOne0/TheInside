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
        atrapar();
    }
    void atrapar()
    {
        agent.SetDestination(objective.transform.position);
        StartCoroutine(WaitAndDie());
    }
    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        //Poner el audio del pablo mueriendo aquí
    }
}
