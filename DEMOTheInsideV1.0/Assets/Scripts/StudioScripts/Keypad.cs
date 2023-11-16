using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    public string password = "1357924680";
    private string userInput = "";

    public AudioClip clickSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    AudioSource audioSource;

    private void Start()
    {
        userInput = "";
        audioSource = GetComponent<AudioSource>();
    }
    public void ButtonClicked(string number)
    {
        audioSource.PlayOneShot(clickSound);
        userInput += number;
        if(userInput.Length  >= 10)
        {
            //Check password
            if(userInput  == password)
            {
                //Sound correct and open door
                Debug.Log("Entry Allowed");
                audioSource.PlayOneShot(correctSound);
            }
            else
            {
                Debug.Log("Not this time");
                //Play sound
                userInput = "";
                audioSource.PlayOneShot(incorrectSound);
            }
        }
    }
}
