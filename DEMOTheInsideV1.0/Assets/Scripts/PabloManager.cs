using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PabloManager : MonoBehaviour
{
    [SerializeField] private GameObject Pablo; // prefab de Pablo
    //spawnpoints
    [SerializeField] private Transform[] spawnpointsArriba; // Array de spawnpoints de Arriba
    //cooldown
    public float minCooldown = 180.0f; // Minimo cooldown (en segundos)
    public float maxCooldown = 300.0f; // Maximo cooldown (en segundos)
    //bools areas
    [SerializeField] private bool Arriba = false;
    [SerializeField] private bool Lock = false;

    //public DesaparecerPablo PabloDeath;
    public bool PabloPresent=false;


    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(EventosPabloArriba());
        //LockPablo();
    }

    IEnumerator EventosPabloArriba()
    {
       

        for (int i = 0; i < 1; i++)
        {
            if (Arriba == true && Lock==false && PabloPresent==false)
            {
                int randomSpawnIndex = Random.Range(0, spawnpointsArriba.Length);
                Vector3 spawnPosition = spawnpointsArriba[randomSpawnIndex].position;

                // Instanciar el prefab
                Instantiate(Pablo, spawnPosition, Quaternion.identity);
                Lock = true;

                //yield return StartCoroutine(Cooldown());

                
                float cooldownTime = Random.Range(minCooldown, maxCooldown);


                yield return new WaitForSeconds(cooldownTime);
                Lock = false;
            }
        }
    }

    /*void LockPablo()
    {
        if(Lock== true)
        {
            GetComponent<BoxCollider>().enabled=false;
            
        }
        else if (Lock == false)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }*/

    /*IEnumerator Cooldown()
    {
        // Generar random cooldown 
        float cooldownTime = Random.Range(minCooldown, maxCooldown);
        yield return new WaitForSeconds(cooldownTime);
    }*/

    private void OnTriggerEnter (Collider other)
    {
        if (Arriba == false)
        {
            Arriba = true;
        }
        else
        {
            Arriba = false;
        }
    }

}
