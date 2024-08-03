using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenu;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void MainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
