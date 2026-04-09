using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class StartFishing : MonoBehaviour, IInteractable
{
    public GameObject playerControl, fish;
    public GameObject minigameScreen;
    public DropTableData dropTable;
    public Animator animator;
    public TextMeshProUGUI result;
    private bool isFishing, gameRunning, playerWon;
    private GameObject details;
    
    public bool CanInteract()
    {
        return !isFishing;
     }

    public void Interact()
    {
        if ((playerControl.activeSelf == false && !isFishing) || minigameScreen.activeSelf == true)
        {
            return;
        }
        else if (playerControl.activeSelf == false && isFishing && !gameRunning)
        {
            playerWon = false;
            StopFish();
        }
        else
        {
            StartFish();
        }
    }

    void StartFish()
    {
        isFishing = true;
        gameRunning = false;
        playerControl.SetActive(false);
        animator.SetBool("isFishing", true);
        details = GameObject.Find("WorldName");
        fish.GetComponent<RectTransform>() .SetLocalPositionAndRotation(new Vector2(0f, -150f), Quaternion.identity);
        StartMinigame();
    }

    void StartMinigame()
    {
        int randStart = Random.Range(0, 10);
        if (randStart == 7)
        {
            details.SetActive(false);
            minigameScreen.SetActive(true);
            gameRunning = true;
        }
        else
        {
            StartCoroutine(WaitForCheck());
        }
        
    }

    void Update()
    {
        if (isFishing && gameRunning)
        {
            CheckGameRunning();
        }
    }
    void CheckGameRunning()
    {
        CheckStatus checkStatus = fish.GetComponent<CheckStatus>();
        int win = checkStatus.ReturnWinStat();
        if (win == -1)
        {
            return;
        }
        else
        {
            StartCoroutine(ShowStatus(CheckWin(win)));
        }
    }
    private bool CheckWin(int winStat)
    {
        if (winStat == 0)
        {
            playerWon = false;
        }
        else
        { 
            playerWon = true;
        }
        return playerWon;
    }

    IEnumerator WaitForCheck()
    {
        yield return new WaitForSeconds(1.0f);
        StartMinigame();
    }
    IEnumerator ShowStatus(bool win)
    {
        yield return new WaitForSeconds(3.0f);
        StopFish();
    }

    private ItemData itemFound()
    {
        for (int idx = 0; idx < dropTable.entries.Length; idx++)
        {
            float chance = Random.Range(0f, 100f);
            if (dropTable.entries[idx].chance >= chance)
            {
                ItemData caught = dropTable.entries[idx].item;
                result.text = "You received: " + caught.itemName;
                return caught;
            }
        }
    return null;
    }

    void StopFish()
    {
        if (playerWon)
        {
            ItemData caught = itemFound();
            if (caught == null)
            {
                result.text = "Nothing was caught.";
            }
            else if (RuntimeInventory.Instance == null)
            {
                result.text = "RuntimeInventory not found in scene.";
            }
            else
            {
                RuntimeInventory.Instance.AddItem(caught);
            }
        }
        StopAllCoroutines();
        isFishing = false;
        playerControl.SetActive(true);
        minigameScreen.SetActive(false);
        details.SetActive(true);
        animator.SetBool("isFishing", false);
    }
}
