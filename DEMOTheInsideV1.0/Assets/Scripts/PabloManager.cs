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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EventosPabloArriba());
    }

    IEnumerator EventosPabloArriba()
    {
        if (spawnpointsArriba.Length == 0 || Pablo == null)
        {
            Debug.LogError("problemas con los spawnpoints de arriba");
            yield break;
        }

        for (int i = 0; i < 1; i++)
        {
            if (Arriba == true)
            {
                int randomSpawnIndex = Random.Range(0, spawnpointsArriba.Length);
                Vector3 spawnPosition = spawnpointsArriba[randomSpawnIndex].position;

                // Instanciar el prefab
                Instantiate(Pablo, spawnPosition, Quaternion.identity);

                yield return StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        // Generar random cooldown 
        float cooldownTime = Random.Range(minCooldown, maxCooldown);
        yield return new WaitForSeconds(cooldownTime);
    }

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
