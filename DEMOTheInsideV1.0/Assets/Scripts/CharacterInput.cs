using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    //Movement variables
    public CharacterController controller;
    public float speed = 16;

    //Inside/Outside Varibles
    public bool Inside = false;

    //1st Puzzle variables
    public GameObject Inventory;
    public GameObject ActualPic;
    public GameObject DropPos;
    public bool ItemHold;

    //TP Variables
    public static bool ExitBoolCI= false;
    public GameObject StartPoint;

    //FousVariables
    Camera cam;


    private void Start()
    {
        Inventory = GameObject.Find("Inventory");
        DropPos = GameObject.Find("DropPos");
        StartPoint = GameObject.Find("StartPoint");
        cam = Camera.main;
        ItemHold = false;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (ItemHold ==false && other.gameObject.tag == "C" && Input.GetKeyDown(KeyCode.F))
        {

            ActualPic= other.gameObject;
            ItemHold = true;
           ActualPic.transform.position = Inventory.transform.position;
            //transform.rotation = leftRot;
        }

        else if (ItemHold == true && other.gameObject.tag == "CPos" && Input.GetKeyDown(KeyCode.F))
        {


            ActualPic.transform.position = other.transform.position;
            ItemHold = false;
            //transform.rotation = leftRot;
        }
        else if (other.gameObject.tag == "Exit" /*&& Input.GetKeyDown(KeyCode.F)*/)
        {
            ExitBoolCI = true;
            Debug.Log("Works1");
            
            
        }
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Exit" && Input.GetKeyDown(KeyCode.F))
        {
            ExitBool = true;
        }
    }*/



    void Update()
    {
        Movement();
        AmbientC();
        Drop();
        TP();

        
    }


    //Esta función es para que podamos cambiar entre el inside y el outside
    /*private void OnTriggerEnter(Collider other)
    {
        
    }*/

   

    void AmbientC()
    {
     if (Inside = false && Input.GetKeyDown(KeyCode.Tab))
        {

            Debug.Log(" Inside");
            Inside = true;

        }
     else if(Inside = true && Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Cambio de perspectiva al Outside");
            Inside = false;
        }

    }

    //Función de Movimiento
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    void Drop()
    {
        if (ItemHold == true && Input.GetKeyDown(KeyCode.G))
        {
            ActualPic.transform.position = DropPos.transform.position;
            ItemHold = false;
        }
    }

    void TP()
    {
        //ExitBoolGM = CharacterInput.ExitBoolCI;
        //Debug.Log("WORK1");
        if (ExitBoolCI == true)
        {

            transform.position = StartPoint.transform.position;
            ExitBoolCI = false;
            //ExitBoolGM = false;
            Debug.Log("WORK1000");
        }
    }




}