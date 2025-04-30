using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform movePoint;
    public Inventory inventory;

    public LayerMask whatStopsMovement;

    [Header("Required Managers")]
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        inventory = new Inventory();  // Initialize the inventory here

        // Ensure the managers are set up correctly
        if (inventoryManager == null)
            Debug.LogError("InventoryManager is not assigned in GridMovement.");
        if (uiManager == null)
            Debug.LogError("UIManager is not assigned in GridMovement.");
    }

    void Start()
    {
        movePoint.parent = null;

        // Optionally: Initialize UI
        if (uiManager != null)
            uiManager.UpdateUI();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
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
