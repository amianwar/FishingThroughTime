using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject player;
    public InputAction MoveAction;
    public float moveSpeed = 4.0f; //new
    private Vector2 move; //new
    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        Time.timeScale = 1.0f;
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>(); //used RigitBody2D to reflect player obj
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isWalking", true);

        if (!MoveAction.IsPressed())
        {
            animator.SetBool("isWalking", false);
            move = Vector2.zero; //new
        }
        else
        {
            move = MoveAction.ReadValue<Vector2>();
            animator.SetFloat("LastInputX", move.x); //taking the last input of x and y to keep animation aligned with last pressed key
            animator.SetFloat("LastInputY", move.y);
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", move.x);
            animator.SetFloat("InputY", move.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}
