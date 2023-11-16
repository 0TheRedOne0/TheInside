using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string password = "1357924680";
    private string userInput = "";


    private void Start()
    {
        userInput = "";
    }
    public void ButtonClicked(string number)
    {
        userInput += number;
        Debug.Log(userInput);
    }
}
