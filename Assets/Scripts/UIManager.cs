using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject inventoryPanel;
    public Image[] itemImages;

    [Header("Required Managers")]
    [SerializeField] private InventoryManager inventoryManager;

    private void OnEnable()
    {
        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is NULL in UIManager! Make sure it's assigned.");
            return;
        }

        Debug.Log("Subscribing to OnInventoryUpdated.");
        inventoryManager.OnInventoryUpdated += UpdateUI;
    }

    private void OnDisable()
    {
        if (inventoryManager != null)
        {
            inventoryManager.OnInventoryUpdated -= UpdateUI;
        }
    }

    public void UpdateUI()
    {
        Debug.Log("UpdateUI called!");

        if (inventoryManager == null)
        {
            Debug.LogError("InventoryManager is NULL in UIManager!");
            return;
        }

        List<Sprite> items = inventoryManager.GetCollectedItems();
        Debug.Log("Updating UI. Items in inventory: " + items.Count);

        for (int i = 0; i < itemImages.Length; i++)
        {
            if (i < items.Count)
            {
                Debug.Log($"Setting UI slot {i} with sprite: {items[i].name}");
                itemImages[i].sprite = items[i];
                itemImages[i].enabled = true;
                itemImages[i].color = Color.white;
            }
            else
            {
                Debug.Log($"Clearing UI slot {i}");
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
            }
        }
    }
}
