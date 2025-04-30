using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public event Action OnInventoryUpdated;

    private List<Sprite> collectedItems = new List<Sprite>();

    private void Awake()
    {
        // Optional: log to ensure InventoryManager is initialized
        Debug.Log("InventoryManager initialized for this scene.");
    }

    public void AddItem(Sprite itemSprite)
    {
        if (!collectedItems.Contains(itemSprite))
        {
            collectedItems.Add(itemSprite);
            Debug.Log("Item added to inventory: " + itemSprite.name);
            OnInventoryUpdated?.Invoke();
        }
    }

    public void RemoveItem(Sprite itemSprite)
    {
        if (collectedItems.Contains(itemSprite))
        {
            collectedItems.Remove(itemSprite);
            Debug.Log("Item removed from inventory: " + itemSprite.name);
            OnInventoryUpdated?.Invoke();
        }
        else
        {
            Debug.LogWarning("Attempted to remove item that isn't in inventory: " + itemSprite.name);
        }
    }

    public List<Sprite> GetCollectedItems()
    {
        return collectedItems;
    }

    public bool HasItem(Sprite itemSprite)
    {
        return collectedItems.Contains(itemSprite);
    }
}
