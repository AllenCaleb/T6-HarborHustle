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

    public void NextLevel()
    {
        // Get the next level's scene index and load it
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Loads the next scene in the build settings
        }
        else
        {
            Debug.Log("No more levels available.");
        }

    }

}

