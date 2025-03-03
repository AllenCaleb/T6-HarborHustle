using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        if (itemSlotContainer == null)
        {
            Debug.LogError("itemSlotContainer not found! Please ensure it's in the hierarchy.");
            return;
        }
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        if (itemSlotTemplate == null)
        {
            Debug.LogError("itemSlotTemplate not found! Ensure it exists inside itemSlotContainer.");
            return;
        }
    }

    public void SetInventory(Inventory inventory)
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory reference is NULL in SetInventory!");
            return;
        }

        this.inventory = inventory;
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems()
    {
        Debug.Log("Refreshing inventory UI... Total Items: " + inventory.GetItems().Count);

        
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 60f;

        foreach (Item item in inventory.GetItems())
        {
            Debug.Log("Displaying item in UI: " + item.itemType);

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);

            Transform imageTransform = itemSlotRectTransform.Find("image");
            if (imageTransform == null)
            {
                Debug.LogError("No 'image' GameObject found in itemSlotTemplate!");
                continue;
            }

            Image image = imageTransform.GetComponent<Image>();
            if (image == null)
            {
                Debug.LogError("'image' GameObject is missing an Image component!");
                continue;
            }

            if (item.GetSprite() == null)
            {
                Debug.LogError("Item.GetSprite() returned null for " + item.itemType);
                continue;
            }

            image.sprite = item.GetSprite();
            Debug.Log("Successfully displayed: " + item.itemType);

            x++;
            if (x >= 4)
            {
                x = 0;
                y++;
            }
        }
    }

}
