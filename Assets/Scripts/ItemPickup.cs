using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemSprite; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collected: " + itemSprite.name);

            if (InventoryManager.Instance != null)
            {
                InventoryManager.Instance.AddItem(itemSprite);
            }
            else
            {
                Debug.LogError("InventoryManager instance is NULL!");
            }

            Destroy(gameObject); // Remove item from scene
        }
    }
}
