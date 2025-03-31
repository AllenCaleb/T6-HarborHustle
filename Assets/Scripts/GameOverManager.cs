using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject PlayerDeathUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayerDeath()
    {
        PlayerDeathUI.SetActive(true);
    }

    public void resart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
