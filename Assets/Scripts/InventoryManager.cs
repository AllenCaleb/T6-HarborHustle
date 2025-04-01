using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public event Action OnInventoryUpdated;

    private List<Sprite> collectedItems = new List<Sprite>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddItem(Sprite itemSprite)
    {
        if (!collectedItems.Contains(itemSprite))
        {
            collectedItems.Add(itemSprite);
            Debug.Log("Item added to inventory: " + itemSprite.name);

            OnInventoryUpdated?.Invoke(); // Trigger UI Update
        }
    }

    public List<Sprite> GetCollectedItems()
    {
        Debug.Log("Inventory contains " + collectedItems.Count + " items.");
        foreach (Sprite sprite in collectedItems)
        {
            Debug.Log("- " + sprite.name);
        }
        return collectedItems;
    }

    
}
