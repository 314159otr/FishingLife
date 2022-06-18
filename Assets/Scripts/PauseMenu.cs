using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject dialogo;
    bool habiaDialogo;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                if (habiaDialogo)
                {
                    dialogo.SetActive(true) ;
                    habiaDialogo = false;
                }
            }
            else
            {
                Pause();
                if (dialogo.activeSelf)
                {
                    dialogo.SetActive(false);
                    habiaDialogo = true;
                }
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Salir()
    {

        Application.Quit();
    }
    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("MenuPrincipal");
        
    }
}
