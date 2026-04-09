using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    //ITEM DATA//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public Sprite emptySprite;
    public bool isFull;
    public string itemDescription;

    //ITEM SLOT//
    public TMP_Text quantityText;

    public Image itemImage;
    public GameObject selectedHighlight;
    public bool selected;

    //ITEM DESC SLOT//
    public Image itemDescImage;
    public TMP_Text itemDescNameText;
    public TMP_Text itemDescText;

    public GameObject itemInSlot;

    private InventoryController inventoryController;

    void Start()
    {
        inventoryController = GetComponentInParent<InventoryController>();
    }

    public void SetItem(ItemData item)
    {
        itemName = item.itemName;
        itemSprite = item.icon;
        itemDescription = item.description;
        isFull = true;
        if (quantityText != null) quantityText.text = item.itemName;
        if (itemImage != null) 
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = item.icon;
        }
        if (selectedHighlight != null) selectedHighlight.SetActive(false);
    }
    public void ClearSlot()
    {
        itemName = "";
        isFull = false;
        itemInSlot = null;
        if (quantityText != null) quantityText.text = "";
        if (itemImage != null)
        {
            itemImage.gameObject.SetActive(false); // Turn off when slot empty
            itemImage.sprite = null;
        }
    }
    public void AddItem(ItemData item)
    {
        itemName = item.itemName;
        itemSprite = item.icon;
        itemDescription = item.description;
        if (itemImage != null) itemImage.sprite = itemSprite;
        isFull = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        inventoryController.DeselectAllSlots();
        selectedHighlight.SetActive(true);
        selected = true;

        if (isFull)
        {
            itemDescNameText.text = itemName;
            itemDescText.text = itemDescription;
            itemDescImage.sprite = itemSprite;
        }
        else
        {
            itemDescNameText.text = "";
            itemDescText.text = "";
            itemDescImage.sprite = emptySprite;
        }
    }
}
