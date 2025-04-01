using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemSprite;  // Assign this in the Inspector (image representing the item)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // If the player collects it
        {
            InventoryManager.Instance.AddItem(itemSprite);  // Pass the sprite to the InventoryManager
            Destroy(gameObject);  // Destroy the pickup item from the scene
        }
    }
}
