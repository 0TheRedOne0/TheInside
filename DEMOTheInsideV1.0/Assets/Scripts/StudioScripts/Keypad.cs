using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    [SerializeField ]private Animator Anim;

    public string password = "1234567890";
    private string userInput = "";

    public AudioClip clickSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    AudioSource audioSource;

    private void Start()
    {
        userInput = "";
        audioSource = GetComponent<AudioSource>();
        //Anim = GetComponentInChildren<Animator>();
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
                Anim.SetTrigger("DoorOpen");
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
