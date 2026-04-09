using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject playerControl;
    public GameObject inventoryMenu;
    public GameObject watch;
    public GameObject logbook;
    private bool inventoryOpen;
    private InventoryController inventoryController;

    void Start()
    {
        inventoryController = GetComponent<InventoryController>();
    }

    public void Interact()
    {
        // If watch or logbook are open, close them and open inventory
        if (watch.activeSelf || logbook.activeSelf)
        {
            watch.SetActive(false);
            logbook.SetActive(false);            
            inventoryController.DeselectAllSlots();
            inventoryMenu.SetActive(true);
            inventoryOpen = true;
        }
        // If inventory is already open, close it
        else if (inventoryOpen)
        {
            inventoryMenu.SetActive(false);
            inventoryOpen = false;
            playerControl.SetActive(true);
        }
        // Otherwise just open inventory
        else
        {
            inventoryController.DeselectAllSlots();
            inventoryMenu.SetActive(true);
            inventoryOpen = true;
            playerControl.SetActive(false);
        }
    }

    public void OnInteract(InputAction.CallbackContext cont)
    {
        if (cont.performed)
        {
            Interact();
        }
    }

    public void AddItem(ItemData item)
    {
        
    }
}