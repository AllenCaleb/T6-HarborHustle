using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private UI_Inventory UI_Inventory;
    public float movementSpeed = 5f;
    public Transform movePoint;
    private Inventory inventory;

main
    public LayerMask whatStopsMovement;

    private void Awake()
    {
        inventory = new Inventory(); // Ensure inventory is created before UI setup
    }

    void Start()
    {
        //Movement
        movePoint.parent = null;


        if (UI_Inventory == null)
        {
            Debug.LogError("UI_Inventory reference is missing in GridMovement! Assign it in the Inspector.");
            return;
        }

        if (inventory == null)
        {
            Debug.LogError("Inventory is NULL in GridMovement at Start!");
            return;
        }

        UI_Inventory.SetInventory(inventory); // Now inventory should not be null
 main
    }



    void Update()
    {
        //Movement
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
 main

    public void AddItemToInventory(Item.ItemType itemType)
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory is NULL in GridMovement!");
            return;
        }

        inventory.AddItem(new Item { itemType = itemType, amount = 1 });

        // Print current inventory contents
        Debug.Log("Added " + itemType + " to inventory.");
        Debug.Log("Current Inventory Items:");
        foreach (Item item in inventory.GetItems())
        {
            Debug.Log("- " + item.itemType);
        }

        UI_Inventory.SetInventory(inventory); // Refresh UI
    }

}

