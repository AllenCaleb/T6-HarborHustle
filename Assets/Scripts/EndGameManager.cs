using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Item;

public class EndGameManager : MonoBehaviour
{
    public int totalCollectibles; 
    public GameObject EndPoint;
    public GameObject gameOverUI;

    private int collectibleCount = 0;
    private bool gameEnd = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GridMovement gridMovement = other.gameObject.GetComponent<GridMovement>();
            List<Item> inventoryitems = gridMovement.inventory.GetItems();
            ItemType itemToFind = Item.ItemType.Docs;

            for (int i = 0; i < inventoryitems.Count; i++)
            {
                if (inventoryitems[i].itemType == itemToFind)
                {
                    GameOver();
                }
            }
        }
    }

    public void GameOver()
    {
        if (!gameEnd)
        {
            gameOverUI.SetActive(true); 
            gameEnd = true; 
        }
    }
}
