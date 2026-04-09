using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FishController : MonoBehaviour
{
    public GameObject fish;
    public GameObject fishingScreen;

    public InputAction MoveAction;
    void Start()
    {
        fish.GetComponent<RectTransform>() .SetLocalPositionAndRotation(new Vector2(0f, -150f), Quaternion.identity);
        MoveAction.Enable();
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        bool fishMoving = Keyboard.current.wKey.wasPressedThisFrame;
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Vector2 pos = (Vector2)fish.transform.position;
    
        if (fishMoving)
        { 
            pos.y += move.y * 20.0f * Time.deltaTime;
        }
        else 
        {
            pos.y -= 20.0f * Time.deltaTime;
        }
        pos += move * 100.0f * Time.deltaTime;
        fish.transform.position = pos;

    }
}
