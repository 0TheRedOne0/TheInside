using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalManager : MonoBehaviour
{
    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Final");
        }
    }
}
