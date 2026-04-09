using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogBookEntry : MonoBehaviour
{
    //assign matching itemdata in inspector
    public ItemData fish;
    //assign child iumage and text in inspector
    public Image fishImage;
    public TMP_Text fishNameText;

    //assign placeholder sprite in inpsector
    public Sprite unknownFishSprite;

    void Awake()
    {
        //sub to discovery events
        if (RuntimeInventory.Instance != null)
            RuntimeInventory.Instance.OnSpeciesDiscovered += OnSpeciesDiscovered;

        Refresh();
    }

    void OnEnable()
    {
        Refresh();
    }

    void OnDestroy()
    {
        if (RuntimeInventory.Instance != null)
            RuntimeInventory.Instance.OnSpeciesDiscovered -= OnSpeciesDiscovered;
    }

    void OnSpeciesDiscovered(ItemData discoveredItem)
    {
        if (discoveredItem == fish)
            Refresh();
    }

    public void Refresh()
    {
        if (fish == null || RuntimeInventory.Instance == null || fishImage == null || fishNameText == null) return;

        if (RuntimeInventory.Instance.isDiscovered(fish))
        {
            //fish has been caught, show data
            if (fishImage != null) fishImage.sprite = fish.icon;
            if (fishNameText != null) fishNameText.text = fish.itemName;
        }
        else
        {
            //fish not caught, show placeholder
            if (fishImage != null) fishImage.sprite = unknownFishSprite;
            if (fishNameText != null) fishNameText.text = "???";
        }
    }

}
