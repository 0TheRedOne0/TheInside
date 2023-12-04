using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFunc : MonoBehaviour
{
    public GameObject R1;
    public GameObject R2;
    public GameObject R3;
    public GameObject R4;

    public GameObject selected;

    //private Quaternion Mas40Y;




    [SerializeField] private Vector3 rot;
    [SerializeField] private float speed;
    public int keys;
    



    void Start()
    {
        //Mas40Y = new Quaternion(0f, 40f, 0f, 0f);
        R1 = GameObject.Find("R1");
        R2 = GameObject.Find("R2");
        R3 = GameObject.Find("R3");
        R4 = GameObject.Find("R4");
        selected = R1;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "K")
        {
            Debug.Log("In");
            keys++;
            
        }


    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "K")
        {
            Debug.Log("Out");
            keys--;

        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Lock();
        Rselect();
        Rrotation();
    }

    void Lock()
    {
        if (keys == 4)
        {
            Debug.Log("You Win!!");
        }

    }
    void Rselect()
    {
        //Select

        if (Input.GetKeyDown("1"))
        {
            Debug.Log("Rueda1");
            selected = R1;
        }
        else if (Input.GetKeyDown("2"))
        {
            Debug.Log("Rueda2");
            selected = R2;
        }
        else if (Input.GetKeyDown("3"))
        {
            Debug.Log("Rueda3");
            selected = R3;
        }
        else if (Input.GetKeyDown("4"))
        {
            Debug.Log("Rueda4");
            selected = R4;
        }

    }
    void Rrotation()
    {
        if (Input.GetKey(KeyCode.Z)) rot = Vector3.up;
        else if (Input.GetKey(KeyCode.X)) rot = Vector3.down;
        else rot = Vector3.zero;

        selected.transform.Rotate(rot * speed * Time.deltaTime);
        Debug.Log("Works");
    }
}
