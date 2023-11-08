using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerPablo : MonoBehaviour
{
    public float disappearTime = 3f;  // Time in seconds before the object disappears
    private bool isLookingAtObject = false;
    private float timeLooking = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            isLookingAtObject = true;
        }
        else
        {
            isLookingAtObject = false;
        }

        if (isLookingAtObject)
        {
            timeLooking += Time.deltaTime;

            if (timeLooking >= disappearTime)
            {
                Destroy(gameObject); // This destroys the object when the timer expires
            }
        }
        else
        {
            timeLooking = 0f; // Reset the timer if not looking at the object
        }
    }
}
