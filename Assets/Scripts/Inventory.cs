using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        if (newItem.isStackable)
        {
            Item existingItem = items.Find(item => item.itemName == newItem.itemName);
            if (existingItem != null)
            {
                existingItem.quantity++;
            }
            else
            {
                items.Add(newItem);
            }
        }
        else
        {
            items.Add(newItem);
        }
    }

    public void RemoveItem(Item itemToRemove)
    {
        items.Remove(itemToRemove);
    }
}
