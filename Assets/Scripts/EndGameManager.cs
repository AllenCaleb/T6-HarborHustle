using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Item;

public class EndGameManager : MonoBehaviour
{
    public int totalCollectibles; 
    public GameObject EndPoint;
    public GameObject GameEndUi;

    private int collectibleCount = 0;
    private bool gameEnd = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger!");

            // Get GridMovement component from player
            PlayerMovement PlayerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (PlayerMovement == null)
            {
                Debug.LogError("PlayerMovement not found on Player object!");
                return;
            }

            // Check if inventory is null or empty
            if (PlayerMovement.inventory == null || PlayerMovement.inventory.GetItems().Count == 0)
            {
                Debug.Log("Player inventory is empty! Triggering Game Over.");
                GameOver();
            }
            else
            {
                // If inventory is not empty, log the items in inventory
                Debug.Log("Player's inventory is not empty.");
                List<Item> inventoryItems = PlayerMovement.inventory.GetItems();
                foreach (var item in inventoryItems)
                {
                    Debug.Log($"Item in inventory: {item.itemType}");
                }
            }
        }
    }



    public void GameOver()
    {
        if (!gameEnd)
        {
            GameEndUi.SetActive(true); 
            gameEnd = true; 
        }
    }
}
