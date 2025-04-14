using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    // For pushing crates
    private Rigidbody2D crateRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Ensure diagonal movement is not too fast
        if (moveInput.x != 0 && moveInput.y != 0)
        {
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                moveInput = new Vector2(moveInput.x, 0);
            }
            else
            {
                moveInput = new Vector2(0, moveInput.y);
            }
        }

        // Apply player movement
        rb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true);

        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

  /*  void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with has the "crate" tag
        if (collision.gameObject.CompareTag("Crate"))
        {
            crateRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // If the crate has a Rigidbody2D, apply force to it in the direction the player is moving
            if (crateRb != null)
            {
                Vector2 pushDirection = moveInput.normalized; // Direction the player is moving in
                crateRb.velocity = pushDirection * moveSpeed; // Push the crate in that direction
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Reset crate when no longer in contact with the player
        if (collision.gameObject.CompareTag("Crate"))
        {
            crateRb = null;
        }
    } */
}
