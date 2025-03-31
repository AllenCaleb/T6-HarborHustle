using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;         // Reference to the pause menu UI
    [SerializeField] GameObject dialoguePrefab;    // Reference to the DialoguePrefab GameObject (drag the prefab or the instance here)

    public void Pause()
    {
        pauseMenu.SetActive(true);      // Show the pause menu
        Time.timeScale = 0;             // Pause the game
        if (dialoguePrefab != null)
        {
            dialoguePrefab.SetActive(false); // Hide the DialoguePrefab when paused
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;             // Unpause the game when returning to the main menu
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);     // Hide the pause menu
        Time.timeScale = 1;             // Resume the game
        if (dialoguePrefab != null)
        {
            dialoguePrefab.SetActive(false); // Hide the DialoguePrefab when resuming
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
        GameManager.Instance.ResetData();
        Time.timeScale = 1;             // Ensure the game is unpaused after restart
    }
}
