using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public int totalCollectibles; 
    public GameObject EndPoint;
    public GameObject gameOverUI;

    private int collectibleCount = 0;
    private bool gameEnd = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Collectible"))
        {
            collectibleCount++;
            Destroy(other.gameObject); 
        }

        
        else if (other.gameObject.CompareTag("Player") && collectibleCount == totalCollectibles)
        {
            GameOver();
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
