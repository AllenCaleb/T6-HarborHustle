using UnityEngine;

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

    // Function to reset data when reset button or zone is triggered
    public void ResetData()
    {
        collectedItems = 0;
        boxPositions = new Vector3[0]; // Clear box positions
    }
}
