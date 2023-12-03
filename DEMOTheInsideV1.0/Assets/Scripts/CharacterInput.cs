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
    public Material[] OutsidetMats;
    public GameObject GVOut;
    public GameObject GVIn;
    public string PropertyName = "_Inside";

    //1st Puzzle variables
    public GameObject Inventory;
    public GameObject InventoryT;
    public GameObject ActualPic;
    public GameObject DropPos;
    public bool ItemHold;

    //2nd Puzzle variables
    public GameObject CamRC;
    public GameObject CamMain;
    private bool Rompiendo = false;
    public GameObject RCpos;


    //TP Variables
    public  bool ExitBoolCI = false;
    public GameObject StartPoint;

    //FousVariables
    Camera cam;
    public GameObject cam2;
    public GameObject cam3;
    public bool Focus;
    private bool Focus2;
    private bool Focus3;

    //RaycastVariables
    [SerializeField] private Material SelectedMat;
    [SerializeField] private Material DefaultMat;
    private Transform selection_;

    //DoorOpener
    private bool OpenDoor1;
    private bool OpenDoor2;
    private bool OpenDoor3;
    private bool OpenDoor4;
    public Animator Door1;
    public Animator Door2;
    public Animator Door3;
    public Animator Door4;
    public GameObject Perilla1;
    public GameObject DoorBath;
    public GameObject DoorKitchen;
    public GameObject DoorExit;

    [Header("Sonidos")]
    //SonidosVariables
    private AudioSource audioSource;
    public AudioClip Sonido;//hay que poner uno por sonido, preferiblemente con su nombre
    //para poner que suene un sonido solo ponen PlaySound(nombre del sonido);




    private void Start()
    {
        Inventory = GameObject.Find("Inventory");
        InventoryT= GameObject.Find("InventoryT");
        DropPos = GameObject.Find("DropPos");
        StartPoint = GameObject.Find("StartPoint");
        cam = Camera.main;
        OpenDoor1=  false;
        OpenDoor2 = false;
        OpenDoor3 = false;
        OpenDoor4 = false;


        ItemHold = false;

        Perilla1 = GameObject.Find("Perilla1");
        DoorKitchen = GameObject.Find("Door2");
        DoorBath = GameObject.Find("Door3");
        DoorExit= GameObject.Find("Door4");
        audioSource = GetComponent<AudioSource>();
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

        if (other.gameObject.tag == "RC" && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Zona RC");
            Cursor.lockState = CursorLockMode.None;
            CamMain.SetActive(false);
            CamRC.SetActive(true);
            Rompiendo = true;
            
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
        Raycast();

        if (Rompiendo == true && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Locked;
            this.transform.position = RCpos.transform.position;
            CamMain.SetActive(true);
            CamRC.SetActive(false);
        }
    }


    //Esta función es para que podamos cambiar entre el inside y el outside
    /*private void OnTriggerEnter(Collider other)
    {
        
    }*/

   

    void AmbientC()
    {
     if (Inside == false && Input.GetKeyDown(KeyCode.Tab))
        {

            Debug.Log(" Inside");
            Inside = true;
            CMP(1f);
            GVOut.SetActive(false);
            GVIn.SetActive(true);

        }
     else if(Inside == true && Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Cambio de perspectiva al Outside");
            Inside = false;
            CMP(0f);
            GVOut.SetActive(true);
            GVIn.SetActive(false);
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
            Focus = true;
            transform.position = StartPoint.transform.position;
            ExitBoolCI = false;
            StartCoroutine(ReCam());
            //ExitBoolGM = false;
            //Debug.Log("WORK1000");

        }
    }

    void Raycast()
    {
        if (selection_ != null)
        {
            var selectionRenderer = selection_.GetComponent<Renderer>();
            selectionRenderer.material = DefaultMat;
            selection_ = null;
        }
        if (Focus == false && Focus2 == false && Focus3 == false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag("C") || selection.CompareTag("Tile") || selection.CompareTag("Bag")
                 || selection.CompareTag("Boton") || selection.CompareTag("LockB") || selection.CompareTag("Lock")
                 || selection.CompareTag("Door") || selection.CompareTag("Collar"))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        DefaultMat = selectionRenderer.material;
                        selectionRenderer.material = SelectedMat;
                    }
                    selection_ = selection;

                }


                if (ItemHold==false &&selection.CompareTag("C") && Input.GetKeyDown(KeyCode.F))
                {
                    ActualPic = selection.gameObject;
                    ItemHold = true;
                    ActualPic.transform.position = Inventory.transform.position;
                }
                if (selection.CompareTag("Tile") && Input.GetKeyDown(KeyCode.F))
                {
                    ActualPic = selection.gameObject;
                    
                    ActualPic.transform.position = InventoryT.transform.position;
                }
                if (selection.CompareTag("Bag") && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("ispressing");
                    ActualPic = selection.gameObject;
                    
                    ActualPic.transform.position = InventoryT.transform.position;
                }
                if (selection.CompareTag("Lock") && Input.GetKeyDown(KeyCode.F))
                {
                    
                    Cursor.lockState = CursorLockMode.None;
                    CamMain.SetActive(false);
                    cam2.SetActive(true);
                    Focus2 = true;
                }

                if (selection.CompareTag("LockB") && Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("CambioCam");
                    Cursor.lockState = CursorLockMode.None;
                    CamMain.SetActive(false);
                    cam3.SetActive(true);
                    Focus3 = true;
                }
                if (selection.CompareTag("Door") && selection.position.Equals(Perilla1.transform.position)&&OpenDoor1==false&&Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("Cumplida");
                    OpenDoor1 = true;
                    Door1.SetTrigger("Abierto");
                }
                else if (selection.CompareTag("Door") && selection.position.Equals(Perilla1.transform.position) && OpenDoor1 == true && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor1 = false;
                    Door1.SetTrigger("Cerrado");
                }
                if (selection.CompareTag("Door") && selection.position.Equals(DoorKitchen.transform.position) && OpenDoor2 == false && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor2 = true;
                    Door2.SetTrigger("Abierto");
                }
                else if (selection.CompareTag("Door") && selection.position.Equals(DoorKitchen.transform.position) && OpenDoor2 == true && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor2 = false;
                    Door2.SetTrigger("Cerrado");
                }
                if (selection.CompareTag("Door") && selection.position.Equals(DoorBath.transform.position) && OpenDoor3 == false && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor3 = true;
                    Door3.SetTrigger("Abierto");
                }
                else if (selection.CompareTag("Door") && selection.position.Equals(DoorBath.transform.position) && OpenDoor3 == true && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor3 = false;
                    Door3.SetTrigger("Cerrado");
                }
                if (selection.CompareTag("Door") && selection.position.Equals(DoorExit.transform.position) && OpenDoor4 == false && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor4 = true;
                    Door4.SetTrigger("Abierto");
                }
                else if (selection.CompareTag("Door") && selection.position.Equals(DoorExit.transform.position) && OpenDoor4 == true && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("Cumplida");
                    OpenDoor4 = false;
                    Door4.SetTrigger("Cerrado");
                }

                if (selection.CompareTag("Collar") && Input.GetKeyDown(KeyCode.F))
                {
                    //OpenDoor = true;
                    
                }
            }

            
        }
        if (Focus3 == true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("ispressingtwice");
            Cursor.lockState = CursorLockMode.Locked;
            CamMain.SetActive(true);
            cam3.SetActive(false);

            Focus3 = false;
        }
        if (Focus2 == true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("ispressingtwice");
            Cursor.lockState = CursorLockMode.Locked;
            CamMain.SetActive(true);
            cam2.SetActive(false);

            Focus2 = false;
        }


    }

    void CMP(float value)
    {
        foreach (Material material in OutsidetMats)
        {
            // Asegúrate de que el material y la propiedad existan antes de intentar modificarla
            if (material != null && material.HasProperty("_Inside"))
            {
                // Cambia el valor de la propiedad en el shader
                material.SetFloat("_Inside", value);
            }
        }
    }


    IEnumerator ReCam()
    {
        yield return new WaitForSeconds(0.5f);
        Focus = false;
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