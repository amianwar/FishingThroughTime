using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenFishInfo : MonoBehaviour
{
    //do a generic script and have it just check the name of the parent
    public Button fishButton;
    public Button closeInfo;
    public GameObject infoPage;
    public GameObject timePeriods;
    public Image img;
    public TextMeshProUGUI fName, desc;
    public ItemData fishData;

    void Start()
    {
        fishButton.onClick.AddListener(OpenInfo);
        closeInfo.onClick.AddListener(CloseInfo);
    }
    
    public void DisplayDetails (ItemData fish)
    {
        if (RuntimeInventory.Instance != null && RuntimeInventory.Instance.isDiscovered(fish))
        {
            img.sprite = fish.icon;
            fName.text = fish.itemName;
            desc.text = fish.description;
        }
        else
        {
            img.sprite = null;
            fName.text = "???";
            desc.text = "";
        }
        
    }
    void OpenInfo()
    {
        timePeriods.SetActive(false);
        infoPage.SetActive(true);
        DisplayDetails(fishData);
    }

    void CloseInfo()
    {
        timePeriods.SetActive(true);
        infoPage.SetActive(false);
    }
}
