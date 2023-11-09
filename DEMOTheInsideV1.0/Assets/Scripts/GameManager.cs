using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables de la Sala
    public GameObject C1pos;
    public GameObject C2pos;
    public GameObject C1;
    public GameObject C2;


    void Start()
    {
        C1 = GameObject.Find("C1");
        C2 = GameObject.Find("C2");
        C1pos = GameObject.Find("Frame1");
        C2pos = GameObject.Find("Frame2");


    }

    void Update()
    {
        Psala(); 
    }

    void Psala()
    {
        if (C1.transform.position.Equals(C1pos.transform.position)&& C2.transform.position.Equals(C2pos.transform.position))
        {
            Debug.Log("Primer Puzzle Completado");

        }
    }


}
