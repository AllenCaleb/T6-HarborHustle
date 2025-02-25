using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemtype = Item.ItemType.Compass, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.Docs, amount = 1 });
        AddItem(new Item { itemtype = Item.ItemType.Coin, amount = 1 });
        Debug.Log(itemList.Count);
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public List<Item> GetItems()
    {
        return itemList;
    }
}
