using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        Debug.Log("Inventory initialized. Items will be added on pickup.");
    }


    public void AddItem(Item item)
    {
        if (item == null)
        {
            Debug.LogError("Trying to add a NULL item to inventory!");
            return;
        }

        itemList.Add(item);
        Debug.Log("Item added: " + item.itemType + " | Total items now: " + itemList.Count);
    }


    public List<Item> GetItems()
    {
        return itemList;
    }
}