using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSettings : MonoBehaviour
{
    public bool RatStand;
    public Animator ThisRat;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        IsStandorDownAnim();
    }

    void IsStandorDownAnim()
    {
        if (RatStand == true)
        {
            ThisRat.SetBool("RatStand", true);
        }
        else if(RatStand == false)
        {
            ThisRat.SetBool("RatStand", false);
        }
    }
}
