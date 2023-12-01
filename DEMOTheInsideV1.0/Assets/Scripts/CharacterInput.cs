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
    private Material OutsidetMat;
    public GameObject GVOut;
    public GameObject GVIn;

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
    public static bool ExitBoolCI = false;
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
    public bool OpenDoor;
    public GameObject DoorRoom;
    public GameObject DoorBath;
    public GameObject DoorKitchen;
    public GameObject DoorExit;




    private void Start()
    {
        Inventory = GameObject.Find("Inventory");
        InventoryT= GameObject.Find("InventoryT");
        DropPos = GameObject.Find("DropPos");
        StartPoint = GameObject.Find("StartPoint");
        cam = Camera.main;
        OpenDoor=false;


        //cam2 = GameObject.Find("Lock").GetComponent<Camera>();
        //cam3 = GameObject.Find("LockB").GetComponent<Camera>();

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
            OutsidetMat.SetFloat("_Inside", 1);
            GVOut.SetActive(false);
            GVIn.SetActive(true);

        }
     else if(Inside == true && Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Cambio de perspectiva al Outside");
            Inside = false;
            OutsidetMat.SetFloat("_Inside", 0);
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
            Debug.Log("WORK1000");
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


                if (selection.CompareTag("C") && Input.GetKeyDown(KeyCode.F))
                {
                    ActualPic = selection.gameObject;
                    ItemHold = true;
                    ActualPic.transform.position = Inventory.transform.position;
                }
                if (selection.CompareTag("Tile") && Input.GetKeyDown(KeyCode.F))
                {
                    ActualPic = selection.gameObject;
                    ItemHold = true;
                    ActualPic.transform.position = InventoryT.transform.position;
                }
                if (selection.CompareTag("Bag") && Input.GetKeyDown(KeyCode.F))
                {
                    //Debug.Log("ispressing");
                    ActualPic = selection.gameObject;
                    ItemHold = true;
                    ActualPic.transform.position = InventoryT.transform.position;
                }
                if (selection.CompareTag("Lock") && Input.GetKeyDown(KeyCode.F))
                {
                    ;
                    Cursor.lockState = CursorLockMode.None;
                    CamMain.SetActive(false);
                    cam2.SetActive(true);
                    Focus2 = true;
                }

                if (selection.CompareTag("LockB") && Input.GetKeyDown(KeyCode.F))
                {

                    Cursor.lockState = CursorLockMode.None;
                    CamMain.SetActive(false);
                    cam3.SetActive(true);
                    Focus3 = true;
                }
                if (selection.CompareTag("Door") && Input.GetKeyDown(KeyCode.F))
                {
                    OpenDoor = true;
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




       
    

    IEnumerator ReCam()
    {
        yield return new WaitForSeconds(0.5f);
        Focus = false;
    }




}