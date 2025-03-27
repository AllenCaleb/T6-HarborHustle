using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public int collectedItems = 0; 
    public Vector3[] boxPositions;


    private void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
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
