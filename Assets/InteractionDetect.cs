using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetect : MonoBehaviour
{
    private IInteractable interactableInRange = null;

    public void OnInteract(InputAction.CallbackContext cont)
    {
        if (cont.performed)
        {
            interactableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
           interactableInRange = interactable; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
           interactableInRange = null; 
        }
    }
}
