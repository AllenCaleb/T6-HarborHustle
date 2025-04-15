using UnityEngine;

public class ItemReveal : MonoBehaviour
{
    [Header("Item Reveal Settings")]
    [Tooltip("The unique key used to track the item reveal state across scenes.")]
    public string revealKey = "FishermanFailItemRevealed";  // Make this editable in Inspector
    [Tooltip("The item GameObject to reveal when conditions are met.")]
    public GameObject item;  // Allow the item to be assigned directly in the Inspector

    void Start()
    {
        // Ensure the item is assigned in the Inspector
        if (item == null)
        {
            Debug.LogError("Item GameObject is not assigned in the Inspector!");
            return;
        }

        // Check PlayerPrefs to see if the item should be revealed
        if (PlayerPrefs.GetInt(revealKey, 0) == 1)
        {
            item.SetActive(true);  // Reveal the item
        }
        else
        {
            item.SetActive(false);  // Keep the item hidden
        }
    }

    // Optionally, you could also expose a public method to manually reveal the item if needed
    public void RevealItem()
    {
        if (item != null)
        {
            item.SetActive(true); // Make item visible
            PlayerPrefs.SetInt(revealKey, 1);  // Mark as revealed in PlayerPrefs
            PlayerPrefs.Save();  // Save to disk
        }
    }

    // Optionally, a method to reset the item reveal (for testing or other purposes)
    public void ResetItemReveal()
    {
        if (item != null)
        {
            item.SetActive(false); // Hide the item again
            PlayerPrefs.SetInt(revealKey, 0);  // Mark as not revealed in PlayerPrefs
            PlayerPrefs.Save();  // Save to disk
        }
    }
}
