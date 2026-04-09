using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FindWorldName : MonoBehaviour
{
    private string[] timePeriods = {"Present Day", "Cenozoic",
    "Mesozoic", "Paleozoic"};
    public TextMeshProUGUI currentTimePeriod;
    void Start()
    {
        currentTimePeriod.text = string.Empty;
        Scene currentScene = SceneManager.GetActiveScene();
        currentTimePeriod.text = timePeriods[currentScene.buildIndex-1];
    }
}
