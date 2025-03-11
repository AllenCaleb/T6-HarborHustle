using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopsMovement;

    public Animator animator;
    void Start()
    {

    }

    private void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");


        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("IsWalkingUp", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("IsWalkingLeft", true);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("IsWalkingDown", true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("IsWalkingRight", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("IsWalkingUp", false);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("IsWalkingLeft", false);
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("IsWalkingDown", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsWalkingRight", false);
        }

    }

   
   /* {
        public Animator animator;
        public bool isNearCrate;  // A flag to check if the player is near a crate
        private bool isPushing;   // A flag to check if the player is pushing the crate

        void Update()
        {
            // Check if the player is near a crate (for this example, assuming isNearCrate is set elsewhere)
            if (isNearCrate && Input.GetKeyDown(KeyCode.W))
            {
                // Trigger pushing animation
                animator.SetBool("IsPushing", true);  // Assuming the animator has a boolean parameter "IsPushing"
                isPushing = true;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                // Stop pushing animation
                animator.SetBool("IsPushing", false);
                isPushing = false;
            }

            // Check for walking animation if not pushing
            if (!isPushing && Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsWalkingUp", true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                animator.SetBool("IsWalkingUp", false);
            }
        }

        // This function could be triggered when the player is near a crate
        // For example, using a trigger zone, raycast, or collision detection
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Crate"))
            {
                isNearCrate = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Crate"))
            {
                isNearCrate = false;
            }
        }*/
    } 
   
}