using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton reference
    public event Action OnInventoryUpdated;

    private List<Sprite> collectedItems = new List<Sprite>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
            Debug.Log("InventoryManager Instance is set.");
        }
        else
        {
            Debug.LogWarning("Duplicate InventoryManager found! Destroying this one.");
            Destroy(gameObject);
        }
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
