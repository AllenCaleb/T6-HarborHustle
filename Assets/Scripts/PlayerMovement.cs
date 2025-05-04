using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerMovement : MonoBehaviour
{
    public Inventory inventory;
    [Header("Required Managers")]
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private Rigidbody2D crateRb;

    public float detectionRadius = 1f;
    private bool isNearCrate = false;

    private bool playingFootsteps = false;
    public float footstepSpeed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Optionally: Initialize UI
        if (uiManager != null)
            uiManager.UpdateUI();
    }

    void Update()
    {
        
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
        /*if(rb.velocity.magnitude > 0 && !playingFootsteps)
        {
            StartFootsteps();
        }
        else if (rb.velocity.magnitude == 0)
        {
            StopFootsteps();
        }*/

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
        StartFootsteps();

        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
            StopFootsteps();
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    void StartFootsteps()
    {
        playingFootsteps = true;
        InvokeRepeating(nameof(PlayFootsteps), 0f, footstepSpeed);
    }

    void StopFootsteps()
    {
        playingFootsteps = false;
        CancelInvoke(nameof(PlayFootsteps));
    }

    void PlayFootsteps()
    {
        SoundEffectManager.Play("Footstep");
    }

    

    

    private void Awake()
    {
        inventory = new Inventory();  // Initialize the inventory here

        // Ensure the managers are set up correctly
        if (inventoryManager == null)
            Debug.LogError("InventoryManager is not assigned in GridMovement.");
        if (uiManager == null)
            Debug.LogError("UIManager is not assigned in GridMovement.");
    }



    public void AddItemToInventory(Sprite itemSprite)
    {
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is NULL in GridMovement!");
            return;
        }

        // Add item to the inventory via InventoryManager
        inventoryManager.AddItem(itemSprite);  // Update InventoryManager

        // Optionally, update UI immediately
        if (uiManager != null)
            uiManager.UpdateUI();  // Refresh the UI to reflect the new item
    }
}
