using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables TP
    public GameObject Player;
    public GameObject StartPoint;
    public GameObject Exit;
   
    public bool firstLoop = false;


    //Invntory Pos
    public GameObject Inventory;

    //Variables de la Sala
    public GameObject C1pos;
    public GameObject C2pos;
    public GameObject C3pos;
    public GameObject C4pos;
    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject C4;

    


    //Variables de Timer
    public float timerSec = 00f;
    public float timerMin=00f;
    public float timerHrs= 00f;
    public bool am = true;



    void Start()
    {
        //Sala
        C1 = GameObject.Find("C1");
        C2 = GameObject.Find("C2");
        C3 = GameObject.Find("C3");
        C4 = GameObject.Find("C4");
        C1pos = GameObject.Find("Frame1");
        C2pos = GameObject.Find("Frame2");
        C3pos = GameObject.Find("Frame3");
        C4pos = GameObject.Find("Frame4");

        //TP
        Player= GameObject.Find("FPplayer");
        StartPoint = GameObject.Find("StartPoint");
        Exit = GameObject.Find("Exit");


    }

    void Update()
    {
       
        Psala();
        Timer();
    }

   
   


    void Psala()
    {
        if (C1.transform.position.Equals(C1pos.transform.position)&& C2.transform.position.Equals(C2pos.transform.position) &&
            C3.transform.position.Equals(C3pos.transform.position) && C4.transform.position.Equals(C4pos.transform.position))
        {
            Debug.Log("Primer Puzzle Completado");
            firstLoop = true;

        }
    }

    void Timer()
    {
        //Debug.Log("La hora es:" + timerMin);
        if (firstLoop == true)
        {
            StartCoroutine(addNum());
        }
        if (timerSec >= 60)
        {
            timerSec = 00f;
            timerMin++;
        }
        if (timerMin >= 60)
        {
            timerMin = 00f;
            timerHrs++;
        }
        if (timerHrs >= 12f)
        {
            am = false;
        }
        if (timerHrs > 12f)
        {
            timerHrs = 01f;
        }
        if(timerHrs<=12&& am == false)
        {
            Debug.Log("EndGame");
        }


    }
    IEnumerator addNum()
    {
        yield return new WaitForSeconds(0.083f);
        timerSec++;
        
    }


}
