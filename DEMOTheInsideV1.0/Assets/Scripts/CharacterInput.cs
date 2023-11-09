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
    public GameObject C1pos;
    public GameObject C2pos;
    public GameObject C3pos;
    public GameObject C4pos;
    public GameObject C5pos;
    public GameObject ActualPic;
    private bool ItemHold = false;


    //FousVariables
    Camera cam;


    private void Start()
    {
        cam= Camera.main;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "C" && Input.GetKeyDown(KeyCode.F))
        {

            ActualPic= other.gameObject;
            ItemHold = true;
           ActualPic.transform.position = Inventory.transform.position;
            //transform.rotation = leftRot;
        }

        else if (ItemHold = true && other.gameObject.tag == "CPos" && Input.GetKeyDown(KeyCode.F))
        {


            ActualPic.transform.position = other.transform.position;
            //transform.rotation = leftRot;
        }

    }
 


    void Update()
    {
        Movement();
        AmbientC();
        

        
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

    


}