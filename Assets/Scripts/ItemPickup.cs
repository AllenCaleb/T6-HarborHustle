using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemSprite;

    private InventoryManager inventoryManager;

    private void Awake()
    {
        // Find the InventoryManager in the scene if not assigned
        inventoryManager = FindObjectOfType<InventoryManager>();

        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager not found in the scene by ItemPickup.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && inventoryManager != null)
        {
            Debug.Log("Player collected: " + itemSprite.name);
            inventoryManager.AddItem(itemSprite);
            Destroy(gameObject); // Remove item from scene
        }
    }
}
