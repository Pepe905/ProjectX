using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausescript : MonoBehaviour
{
    public string mainMenu;
    public GameObject pauseMenu;
    public bool isPaused;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                pauseMenu.SetActive(false);

            }

            else
            {
                Time.timeScale = 0;
                isPaused = true;
                pauseMenu.SetActive(true);

            }
        }

    }
    public void ResumeGame()

    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);

    }


    public void ReturnToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);

    }

}    
