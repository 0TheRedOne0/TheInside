using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public int KeypadNumber = 1;

    public UnityEvent KeypadClicked;

    private void OnMouseDown()
    {
       

        KeypadClicked.Invoke();
        
    }
}
