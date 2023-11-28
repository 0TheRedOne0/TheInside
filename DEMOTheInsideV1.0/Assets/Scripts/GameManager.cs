using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    //Variables TP
    public GameObject Player;
    public GameObject StartPoint;
    public GameObject Exit;
   
   //MonsterVariables
   public CharacterInput Inside;

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

    //Variables de la Cocina
    public PuzzlePiece RC;
    public GameObject camRC;
    public GameObject camMain;
    [SerializeField] private bool RCcomp = false;
    public int Puzzle = 0;

    //Variables de Timer
    public TMP_Text Hrs;
    public TMP_Text Min;
    public float timerSec = 00f;
    public float timerMin=00f;
    public float timerHrs= 00f;
    public bool am = true;

    //Variables de Interfaz
    public bool firstTut;
    private bool Control;
    public GameObject WASD;

    //Loops
    public bool firstLoop = false;
    public bool secondLoop = false;
    public bool thirdLoop = false;
    public bool fourthLoop = false;
    public bool fitfthLoop = false;

    public GameObject ESCloop1;
    public GameObject ESCloop2;
    public GameObject ESCloop3;
    public GameObject ESCloop4;
    public GameObject ESCloop5;
    public GameObject BlockBath;
    public GameObject BlockKitchen;
    public GameObject BlockStudio;
    public GameObject BlockRoom;
    public GameObject BlockLiving;




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

        //Interfaz
        firstTut = true;
        StartCoroutine(waitWASD());


    }

    void Update()
    {
       
        Psala();
        Timer();
        Rompechoya();
        loopManager();
        UIcontrol();



    }

    void UIcontrol()
    {
        if (Control == true && Input.GetKeyDown(KeyCode.C))
        {
            StopCoroutine(waitWASD());
            firstTut = false;
        }
        else if (firstTut == false && Input.GetKeyDown(KeyCode.C))
        {

            WASD.SetActive(true);
        }
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
        Hrs.SetText(timerHrs.ToString("00"));
        Min.SetText(timerMin.ToString("00"));
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

    IEnumerator waitWASD()
    {
        Control = true;

        if (firstTut == true)
        {
            WASD.SetActive(true);
            yield return new WaitForSeconds(12f);
            WASD.SetActive(false);
            firstTut = false;
        }
        Control = false;
    }
    void Rompechoya()
    {
        if (Puzzle >= 9)
        {
            RCcomp = true;
        }
        if (RCcomp == true)
        {
            Debug.Log("Segundo Puzzle terminado");
            camRC.SetActive(false);
            camMain.SetActive(true);
        }
    }
    void loopManager()
    {
        if ( firstLoop == true)
        {
            ESCloop1.SetActive(true);
            BlockRoom.SetActive(false);
        }
        if (secondLoop == true)
        {
            ESCloop2.SetActive(true);
            BlockLiving.SetActive(false);
        }
        if (thirdLoop == true)
        {
            ESCloop3.SetActive(true);
            BlockKitchen.SetActive(false);
        }
        if (fourthLoop == true)
        {
            ESCloop4.SetActive(true);
            BlockBath.SetActive(false);
        }
        if (fitfthLoop == true)
        {
            ESCloop5.SetActive(true);
            BlockStudio.SetActive(false);
        }
        
       
    }


}
