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

    public float detectionRadius = 1f;
    private bool isNearCrate = false;

    private bool playingFootsteps = false;
    public float footstepSpeed = 0.5f;

    private Rigidbody2D crateRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(rb.velocity.magnitude > 0 && !playingFootsteps)
        {
            StartFootsteps();
        }
        else if(rb.velocity.magnitude == 0)
        {
            StopFootsteps();
        }

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

        rb.velocity = moveInput * moveSpeed;

        {

            var crates = GameObject.FindGameObjectsWithTag("Crate");

            foreach (GameObject crate in crates)
            {
                float distanceToCrate = Vector3.Distance(transform.position, crate.transform.position);

                if (distanceToCrate <= detectionRadius)
                {
                    if (!isNearCrate)
                    {
                        isNearCrate = true;
                    }
                    else
                    {
                        isNearCrate = false;
                    }
                }
            }
        }
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

    void StartFootsteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootstep), 0f, footstepSpeed);
    }

    void StopFootsteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootstep));
    }

    void PlayFootstep()
    {
        SoundEffectManager.Play("Footstep");
    }
}
