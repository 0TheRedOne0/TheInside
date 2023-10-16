using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
//variables para pausar el juego
    public static bool IsPaused = false;
    public GameObject pauseMenu;

//para el MainMenu
    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Se cerró el juego");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            
        {
            if(IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        IsPaused = false;
        Debug.Log("Se resumió el juego");
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        IsPaused = true;
        Debug.Log("Se cerró el juego");
    }
    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}