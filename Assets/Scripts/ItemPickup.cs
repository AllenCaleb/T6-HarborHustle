using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item.ItemType itemType; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            GridMovement playerInventory = other.GetComponent<GridMovement>(); 
            if (playerInventory != null)
            {
                playerInventory.AddItemToInventory(itemType);
                Debug.Log("Picked up: + itemType");

                Destroy(gameObject); 
            }
        }
    }
}
