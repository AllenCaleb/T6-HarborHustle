using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Sprite> inventorySprites = new List<Sprite>(); // Stores item images

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddItem(Sprite itemSprite)
    {
        if (!inventorySprites.Contains(itemSprite))
        {
            inventorySprites.Add(itemSprite);
            UIManager.instance.UpdateUI(itemSprite); // Update UI with image
        }
    }
}
