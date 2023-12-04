using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Variables TP
    public GameObject Player;
    public GameObject StartPoint;
    public GameObject Exit;
    public CharacterInput firstB;
   
   //MonsterVariables
    public CharacterInput CI;
    public bool Inside;

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
    private Quaternion Orientc1;
    private Quaternion OrientcGeneral;
 

    

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
    public JumpscareManager JM;

    //Variables de Interfaz
    public bool firstTut;
    private bool Control;
    public GameObject WASD;

    //Loops
    public bool firstLoop = false;
    public bool secondLoop = false;
    public bool thirdLoop = false;
    public bool fourthLoop = false;
    public bool fifthLoop = false;


    public int loopNumGM;
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
    public GameObject InsideLoop1;
    public GameObject InsideLoop2;
    public GameObject InsideLoop3;
    public GameObject InsideLoop4;
    public GameObject InsideLoop5;
    public LockFunc LF;

    public GameObject CamMain;
    public GameObject cam3;

    //mas sonido
    private AudioSource audioSource;
    public AudioClip Campanas;
    public AudioClip Respiracion;
//hay que poner uno por sonido, preferiblemente con su nombre
    //para poner que suene un sonido solo ponen PlaySound(nombre del sonido);




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
        Orientc1 = new Quaternion(0, 0.707106829f, -0.707106829f, 0);
        OrientcGeneral = new Quaternion(-0.5f, 0.5f, -0.5f, 0.5f);

        //TP
        Player = GameObject.Find("FPplayer");
        StartPoint = GameObject.Find("StartPoint");
        Exit = GameObject.Find("Exit");
        //Inside.ExitBoolCI;

        //Interfaz
        firstTut = true;
        StartCoroutine(waitWASD());

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (firstB.ExitBoolCI == true)
        {
            firstLoop = true;
        }
        Inside = CI.Inside;

        Psala();
        Timer();
        Rompechoya();
        loopManager();
        UIcontrol();
        fourthLoop = LF.WinLF;
        TPF();


    }
    void TPF()
    {
        if (fourthLoop == true)
        {
            Player.transform.position = StartPoint.transform.position;
            Cursor.lockState = CursorLockMode.Locked;
            CamMain.SetActive(true);
            cam3.SetActive(false);
        }
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
            secondLoop = true;

        }
        if (C1.transform.position.Equals(C1pos.transform.position) || C1.transform.position.Equals(C2pos.transform.position)
           || C1.transform.position.Equals(C3pos.transform.position) || C1.transform.position.Equals(C4pos.transform.position))
        {
            C1.transform.rotation = Orientc1;
        }
        if (C2.transform.position.Equals(C1pos.transform.position) || C2.transform.position.Equals(C2pos.transform.position)
           || C2.transform.position.Equals(C3pos.transform.position) || C2.transform.position.Equals(C4pos.transform.position))
        {
            C2.transform.rotation = OrientcGeneral;
        }
        if (C3.transform.position.Equals(C1pos.transform.position) || C3.transform.position.Equals(C2pos.transform.position)
           || C3.transform.position.Equals(C3pos.transform.position) || C3.transform.position.Equals(C4pos.transform.position))
        {
            C3.transform.rotation = OrientcGeneral;
        }
        if (C4.transform.position.Equals(C1pos.transform.position)|| C4.transform.position.Equals(C2pos.transform.position)
            ||C4.transform.position.Equals(C3pos.transform.position)||C4.transform.position.Equals(C4pos.transform.position))
        {
            C4.transform.rotation = OrientcGeneral;
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
            PlaySound(Campanas);
        }
        if (timerSec >= 60)
        {
            timerSec = 00f;
            timerMin++;
            PlaySound(Campanas);
        }
        if (timerMin >= 60)
        {
            timerMin = 00f;
            timerHrs++;
            PlaySound(Campanas);
        }
        if (timerHrs >= 12f)
        {
            am = false;
            PlaySound(Campanas);
        }
        if (timerHrs > 12f)
        {
            timerHrs = 01f;
            PlaySound(Campanas);
        }
        if(timerHrs<=12&& am == false)
        {
            Debug.Log("EndGame");
            JM.WaitJump();
            PlaySound(Campanas);
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
            Cursor.lockState = CursorLockMode.Locked;
            thirdLoop = true;
            PlaySound(Respiracion);
        }
    }
    void loopManager()
    {
        
        
        if (Inside == true && loopNumGM == 0)
        {
            InsideLoop1.SetActive(true);
        }else if (Inside == false && loopNumGM == 0)
        {
            InsideLoop1.SetActive(false);
        }
        if (Inside == true && loopNumGM==1)
        {
            InsideLoop1.SetActive(false);
            InsideLoop2.SetActive(true);
        }
        else if (Inside == false && loopNumGM >= 1)
        {
            InsideLoop2.SetActive(false);
        }
        if (Inside == true && loopNumGM >= 2)
        {
            InsideLoop2.SetActive(false);
            InsideLoop3.SetActive(true);
        }
        else if (Inside == false && loopNumGM >= 2)
        {
            InsideLoop3.SetActive(false);
        }
        if (Inside == true && loopNumGM >= 3)
        {
            InsideLoop3.SetActive(false);
            InsideLoop4.SetActive(true);
        }
        else if (Inside == false && loopNumGM >= 4)
        {
            InsideLoop4.SetActive(false);
        }
        if (Inside == true && loopNumGM >= 4)
        {
            InsideLoop3.SetActive(false);
            InsideLoop4.SetActive(true);
        }
        else if (Inside == false && loopNumGM >= 5)
        {
            InsideLoop4.SetActive(false);
        }


        if ( firstLoop == true&& secondLoop ==false)
        {
            ESCloop2.SetActive(true);
            BlockRoom.SetActive(false);
            loopNumGM = 1;
        }else if (secondLoop == true && thirdLoop==false)
        {
            ESCloop2.SetActive(true);
            BlockLiving.SetActive(false);
            loopNumGM = 2;
        }else if (thirdLoop == true && fourthLoop==false)
        {
            ESCloop3.SetActive(true);
            BlockKitchen.SetActive(false);
            loopNumGM = 3;
        }else if (fourthLoop == true && fifthLoop==false)
        {
            ESCloop4.SetActive(true);
            BlockBath.SetActive(false);
            loopNumGM = 4;
        }else if (fifthLoop == true)
        {
            ESCloop5.SetActive(true);
            BlockStudio.SetActive(false);
            loopNumGM = 6;
        }
        
       
    }

    void PlaySound(AudioClip sound)
    {
        // Check if the AudioSource and AudioClip are set
        if (audioSource != null && sound != null)
        {
            // Set the AudioClip to play
            audioSource.clip = sound;

            // Play the sound
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not set.");
        }
    }


}
