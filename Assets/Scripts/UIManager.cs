using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject inventoryPanel;  // Assign in Inspector
    public Image[] itemImages;  // Assign UI images in the Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        InventoryManager.Instance.OnInventoryUpdated += UpdateUI;  // Subscribe to the event
    }

    private void OnDisable()
    {
        InventoryManager.Instance.OnInventoryUpdated -= UpdateUI;  // Unsubscribe to avoid memory leaks
    }

    public void UpdateUI()
    {
        List<Sprite> items = InventoryManager.Instance.GetCollectedItems();

        for (int i = 0; i < itemImages.Length; i++)
        {
            if (i < items.Count)
            {
                itemImages[i].sprite = items[i];  // Assign sprite to image slot
                itemImages[i].enabled = true;  // Show the item image
            }
            else
            {
                itemImages[i].enabled = false;  // Hide empty slots
            }
        }
    }
}
