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

    private void Start()
    {
       
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