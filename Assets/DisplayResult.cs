using UnityEngine;
using System.Collections;
using TMPro;

public class DisplayResult : MonoBehaviour
{
    public GameObject fish;
    public GameObject result;
    private bool canDisplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        result.SetActive(false);
        canDisplay = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckStatus checkStatus = fish.GetComponent<CheckStatus>();
        int win = checkStatus.ReturnWinStat();
        if (win == -1)
        {
            return;
        }
        else
        {
            if (!result.activeSelf && canDisplay == false)
            {
                canDisplay = true;
                Display();
            }
        }
        
    }

    void Display()
    {
        StartCoroutine(WaitToStart());
        StopCoroutine(WaitToStart());
        StartCoroutine(ResultOnScreen());
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(3.0f);
        result.SetActive(true);
    }
    IEnumerator ResultOnScreen()
    {
        yield return new WaitForSeconds(5.0f);
        result.SetActive(false);
        canDisplay = false;
        
    }
}
