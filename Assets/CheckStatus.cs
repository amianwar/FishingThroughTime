using TMPro;
using UnityEngine;

public class CheckStatus : MonoBehaviour
{
    public GameObject fishControl, fish;
    public TextMeshProUGUI status;
    private int winStat =-1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "DetectFishLoss")
        {
            fishControl.SetActive(false);
            winStat = 0;
            status.text = "You lost the fish.";
        }
        else if (collision.gameObject.name == "DetectFishWin")
        {
            fishControl.SetActive(false);
            winStat = 1;
            status.text = "You caught the fish!";
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        fishControl.SetActive(true);
        winStat = -1;
        status.text = "";
    }

    public int ReturnWinStat()
    {
        return winStat;
    }
}
