using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JumpscareManager : MonoBehaviour
{
    //variables
    public GameObject CamJump;
    public GameObject CamMain;
    public GameObject PabloAnim;
    public Animator animP;
    public Animator animC;
    public GameObject CanvasRC;
    public AudioClip mySound; 
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CamMain.gameObject.SetActive(false);
            CamJump.gameObject.SetActive(true);
            PabloAnim.gameObject.SetActive(true);
            StartCoroutine(WaitJump());
        }
    }

    private IEnumerator WaitJump()
    {
        yield return new WaitForSeconds(2f);
        animP.SetBool("Jump", true);
        animC.SetTrigger("Blink");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
        PlaySound();
    }

    void PlaySound()
    {
        // Check if the AudioSource and AudioClip are set
        if (audioSource != null && mySound != null)
        {
            // Play the sound
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not set.");
        }
    }
}
