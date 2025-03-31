using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemSprite; // Assign the item sprite in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            InventoryManager.instance.AddItem(itemSprite);
            Destroy(gameObject); // Remove item from world
        }
    }
}
