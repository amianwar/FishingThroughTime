using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportScript : MonoBehaviour
{
    public Button Teleporter;

    void Start()
    {
        Teleporter.onClick.AddListener(Teleport);
    }
    /*void Update()
    {
        if (Button.ButtonClickedEvent) {
        int currentWorld = SceneManager.GetActiveScene().buildIndex;
        //use counter to see how many times player hits left/right keys to find world index
        SceneManager.LoadScene(currentWorld + 1);
        }   
    }*/
    void Teleport()
    {
        int currentWorld = SceneManager.GetActiveScene().buildIndex;
        //use counter to see how many times player hits left/right keys to find world index
        if (currentWorld > 0)
        {
            SceneManager.LoadScene(currentWorld - 1);
        }
        else if (currentWorld < 1)
        {
            SceneManager.LoadScene(currentWorld + 1);
        }
    }


}
