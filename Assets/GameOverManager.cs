using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour
{
    public GameObject redWinPanel;
    public GameObject blueWinPanel;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(string winer) 
    {
        if(winer == "Red") 
        {
            redWinPanel.SetActive(true);
            blueWinPanel.SetActive(false);
            Time.timeScale = 0;


        }
        else 
        {
            
            blueWinPanel.SetActive(true);
            redWinPanel.SetActive(false);



        }
    }

    public void LoadMainMenu() 
    {
        PauseMenu.instance.ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        PauseMenu.instance.ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
