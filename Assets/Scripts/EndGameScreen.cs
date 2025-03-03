using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    public void Restart()
    {
        // Disable the Game Over UI before reloading the scene
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);  
                                          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }
}
