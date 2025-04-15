using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // A list to store positions (assuming Vector3 positions)
    public Vector3[] boxPositions; // Changed from List<Vector3> to Vector3[] array

    public List<Sprite> unlockedItems = new List<Sprite>();
    public bool isObjectiveCompleted = false; // This will track if the objective is completed.

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this to unlock an item
    public void UnlockItem(Sprite item)
    {
        if (!unlockedItems.Contains(item))
        {
            unlockedItems.Add(item);
            Debug.Log("Item unlocked: " + item.name);
        }
    }

    // Call this when the objective is complete
    public void CompleteObjective()
    {
        isObjectiveCompleted = true;
        Debug.Log("Objective completed!");
    }

    // Reset all the game data (unlock items and objectives)
    public void ResetData()
    {
        unlockedItems.Clear(); // Clear the list of unlocked items
        isObjectiveCompleted = false; // Reset the objective completion status
        boxPositions = new Vector3[0]; // Reset the array if needed
        Debug.Log("Game data has been reset.");
    }
}
