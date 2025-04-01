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
            OnInventoryUpdated?.Invoke();  // Notify that the inventory has been updated
        }
    }

    public List<Sprite> GetCollectedItems()
    {
        return collectedItems;
    }
}
