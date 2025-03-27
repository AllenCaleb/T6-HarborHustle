using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    public float detectionRadius = 1f;
    private bool IsNearCrate = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
      
        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            moveInput.y = 0;  
        }
        else
        {
            moveInput.x = 0;  
        }

        rb.velocity = moveInput * moveSpeed;

        var crates = GameObject.FindGameObjectsWithTag("Crate");

        foreach (GameObject crate in crates)
        {
            float distanceToCrate = Vector3.Distance(transform.position, crate.transform.position);

            if (distanceToCrate >= detectionRadius)
            {
                if (!IsNearCrate)
                {
                    IsNearCrate = true;
                }
                else
                {
                    IsNearCrate = false;
                }
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true);

        if(context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

}
