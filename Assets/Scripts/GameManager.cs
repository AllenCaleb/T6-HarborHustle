using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    public int collectedItems = 0;  // Stores collected items
    public Vector3[] boxPositions;  // Stores box positions

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep it alive across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    
    public void SaveBoxPositions()
    {
        GameObject[] boxObjects = GameObject.FindGameObjectsWithTag("Box");

        if (boxObjects.Length == 0)
        {
            Debug.LogWarning("No boxes found to save positions!");
            return;
        }

        boxPositions = new Vector3[boxObjects.Length];

        for (int i = 0; i < boxObjects.Length; i++)
        {
            boxPositions[i] = boxObjects[i].transform.position;
        }

        Debug.Log("Box positions saved!");
    }

    
    public void RestoreBoxPositions()
    {
        GameObject[] boxObjects = GameObject.FindGameObjectsWithTag("Box");

        if (boxPositions == null || boxPositions.Length != boxObjects.Length)
        {
            Debug.LogWarning("No valid saved box positions found or mismatch in box count!");
            return;
        }

        for (int i = 0; i < boxObjects.Length; i++)
        {
            boxObjects[i].transform.position = boxPositions[i];
        }

        Debug.Log("Box positions restored!");
    }

    
    public void ResetData()
    {
        collectedItems = 0;
        boxPositions = new Vector3[0]; 
        Debug.Log("Game data reset!");
    }
}
