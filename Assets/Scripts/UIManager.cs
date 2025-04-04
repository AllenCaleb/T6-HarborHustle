﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject inventoryPanel; 
    public Image[] itemImages;  

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
        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager Instance is NULL in UIManager! Make sure it's in the scene.");
            return;
        }

        Debug.Log("Subscribing to OnInventoryUpdated.");
        InventoryManager.Instance.OnInventoryUpdated += UpdateUI;
    }


    private void OnDisable()
    {
        InventoryManager.Instance.OnInventoryUpdated -= UpdateUI; 
    }

    public void UpdateUI()
    {
        Debug.Log("UpdateUI called!");

        if (InventoryManager.Instance == null)
        {
            Debug.LogError("InventoryManager is NULL in UIManager!");
            return;
        }

        List<Sprite> items = InventoryManager.Instance.GetCollectedItems();
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
