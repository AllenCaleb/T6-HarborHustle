using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public int quantity;
    public bool isStackable;

    // Constructor
    public Item(string name, Sprite itemIcon, bool stackable)
    {
        itemName = name;
        icon = itemIcon;
        isStackable = stackable;
        quantity = 1;  // Default quantity is 1
    }
}
