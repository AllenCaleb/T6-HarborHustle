using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public GameObject gameOverUI;

    public void Restart()
    {
        
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);  
                                          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }
}
