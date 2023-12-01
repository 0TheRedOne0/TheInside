using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerPablo : MonoBehaviour
{
    public float disappearTime = 3f;  // Time in seconds before the object disappears
    public bool ObjectDetect = false;
    private float timeLooking = 0f;
    public bool PabloAlive = false;

    public PabloManager pabloManager;
    public Animator Pablo2Anim;

    // Start is called before the first frame update
    void Start()
    {
        pabloManager = FindObjectOfType<PabloManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            ObjectDetect = true;
            Pablo2Anim.SetTrigger("dis");

        }
        else
        {
            ObjectDetect = false;
        }

        if (ObjectDetect)
        {
            timeLooking += Time.deltaTime;

            if (timeLooking >= disappearTime)
            {
                Destroy(gameObject); // This destroys the object when the timer expires
                PabloAlive = false;
                pabloManager.PabloPresent = PabloAlive;
            }
        }
        else
        {
            timeLooking = 0f; // Reset the timer if not looking at the object
            PabloAlive = true;
            pabloManager.PabloPresent = PabloAlive;
        }
    }
}
