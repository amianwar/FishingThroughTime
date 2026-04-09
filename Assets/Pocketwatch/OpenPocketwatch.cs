using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPocketwatch : MonoBehaviour, IInteractable
{
    // Creating game objects to turn off/on depending on if the watch is open
    // or not.
    public GameObject playerControl;
    public GameObject Instruct;
    public GameObject Watch;
    public GameObject Logbook;
    public GameObject Inventory;
    public GameObject Name;
    public Animator animator;
    private bool watchOpen;

    public bool CanInteract()
    {
        return !watchOpen;
    }

    public void Interact()
    {

        if (animator.GetBool("isFishing") == true)
        {
            return;
        }
        else
        {
             Name.SetActive(true);
            // If the instructions are visible and the logbook is closed, 
            // disable the instructions, freeze the player camera, and open
            // the pocketwatch.
            if (Instruct.activeSelf && !Logbook.activeSelf && !Inventory.activeSelf)
            {
                Instruct.SetActive(false);
                Watch.SetActive(true);

            }
            // If the instructions are invisible, but the pocketwatch is closed, 
            // close the logbook and open the pocketwatch.
            else if (!Instruct.activeSelf && (Logbook.activeSelf || Inventory.activeSelf))
            {
                Logbook.SetActive(false);
                Inventory.SetActive(false);
                Watch.SetActive(true);
            }
            // If the instruction are invisible, enable them, unfreeze the player 
            // camera, and close the pocketwatch.
            else
            {
                playerControl.SetActive(true);
                Instruct.SetActive(true);
                Watch.SetActive(false);
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext cont)
    {
        if (cont.performed)
        {
            Interact();
        }
    }
}