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

    //2nd Puzzle variables
    public GameObject CamRC;
    public GameObject CamMain;
    private bool Rompiendo = false;
    public GameObject RCpos;


    //TP Variables
    public static bool ExitBoolCI= false;
    public GameObject StartPoint;

    //FousVariables
    Camera cam;
    public bool Focus;

    //RaycastVariables
    [SerializeField] private Material SelectedMat;
    [SerializeField] private Material DefaultMat;
    private Transform selection_;


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

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag("C")|| selection.CompareTag("Tile"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    DefaultMat = selectionRenderer.material;
                    selectionRenderer.material = SelectedMat;
                }
                selection_ = selection;

            }


            //if (selection.CompareTag("C"))
        }

       
    }

    IEnumerator ReCam()
    {
        yield return new WaitForSeconds(0.5f);
        Focus = false;
    }




}