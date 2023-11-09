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


    //FousVariables
    Camera cam;


    private void Start()
    {
        DropPos = GameObject.Find("DropPos");
        cam= Camera.main;
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

    }
 


    void Update()
    {
        Movement();
        AmbientC();
        Drop();
        

        
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
    


}