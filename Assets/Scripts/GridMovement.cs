using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private UI_Inventory UI_Inventory;
    public float movementSpeed = 5f;
    public Transform movePoint;
    private Inventory inventory;

    public LayerMask whatStopsMovement;

    private GameObject ObjToPush;

    private void Awake()
    {
        inventory = new Inventory(); 
    }

    void Start()
    {
        
        movePoint.parent = null;

        ObjToPush = GameObject.FindGameObjectWithTag("ObjToPush");


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

        UI_Inventory.SetInventory(inventory); 
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

        UI_Inventory.SetInventory(inventory); 
    }

    public bool Move(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        /*
        if(Blocked(transformn.position,direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;
        }
        */
    }
    /*
    public bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;

        foreach (var obj in Obstacles)
        {
            if(obj.transform.position.x == newpos.x && ObjToPush.transform.position.y == newpos.y)
            {
                return true;
            }
        }

        foreach (var objToPush in ObjToPush)
        {
            if(ObjToPush.transform.position.x == newpos.x && objToPush.transform/position.y == newpos.y)
            {
                Push objpush = objToPush.GetComponent<Push>();
                if(objpush && objpush.Move(direction))
                {
                    return false;
                }
                {
                    return true;
                }
            }
        }
        return false;
    }
    */

}

