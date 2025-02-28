using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [SerializeField] private UI_Inventory UI_Inventory;
    public float movementSpeed = 5f;
    public Transform movePoint;
    private Inventory inventory;
    // private bool playingFootsteps = false;
    // public float footstepSpeed = 0.5f;
    

    public LayerMask whatStopsMovement;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        inventory = new Inventory();

        UI_Inventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }
    
    



}