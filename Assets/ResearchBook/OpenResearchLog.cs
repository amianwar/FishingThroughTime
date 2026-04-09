using UnityEngine;
using UnityEngine.InputSystem;

public class OpenResearchLog : MonoBehaviour
{
    public GameObject playerControl;
    public GameObject Instruct;
    public GameObject Logbook;
    public GameObject Watch;
    public GameObject Name;
    public GameObject Inventory;
    public Animator animator;
    private bool logOpen;

    public bool CanInteract()
    {
        return !logOpen;
    }

    public void Interact()
    {
        if (animator.GetBool("isFishing") == true)
        {
            return;
        }
        else
        {
            // If the instruction for opening the logbook is visible, disable
            // it, freeze the player camera, and open the logbook.
            if (Instruct.activeSelf && !Watch.activeSelf && !Inventory.activeSelf)
            {
                Instruct.SetActive(false);
                Logbook.SetActive(true);
                Name.SetActive(false);

            }
            // If the instruction for opening the logbook is invisible, but the
            // pocketwatch is open, close the pocketwatch and open the logbook.
            else if (!Instruct.activeSelf && (Watch.activeSelf || Inventory.activeSelf))
            {
                Watch.SetActive(false);
                Inventory.SetActive(false);
                Logbook.SetActive(true);
                Name.SetActive(false);
            }
            // If the instruction are invisible, enable them, unfreeze the player 
            // camera, and close the logbook.
            else
            {
                playerControl.SetActive(true);
                Instruct.SetActive(true);
                Logbook.SetActive(false);
                Name.SetActive(true);
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
