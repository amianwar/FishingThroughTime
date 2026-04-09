using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Button start;
    public Button exit;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start.onClick.AddListener(StartGame);
        exit.onClick.AddListener(ExitGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    void ExitGame()
    {
        Application.Quit();
    }
}
