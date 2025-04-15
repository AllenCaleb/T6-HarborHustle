using UnityEngine;
using UnityEngine.SceneManagement; // Add this for scene management

public class ItemReveal : MonoBehaviour
{
    [Header("Item Reveal Settings")]
    [Tooltip("The unique key used to track the item reveal state across scenes.")]
    public string revealKey = "FishermanFailItemRevealed";  // Make this editable in Inspector
    [Tooltip("The item GameObject to reveal when conditions are met.")]
    public GameObject item;  // Allow the item to be assigned directly in the Inspector

    private bool isRevealed = false;  // Local state for the item reveal

    void Start()
    {
        // Ensure the item is assigned in the Inspector
        if (item == null)
        {
            Debug.LogError("Item GameObject is not assigned in the Inspector!");
            return;
        }

        // Initially hide the item
        item.SetActive(false);

        // If conditions are met, reveal the item (For now this could be based on a trigger or event)
        // Example condition: when the NPC interaction is successful, you can reveal the item
    }

    // Optionally, you could also expose a public method to manually reveal the item if needed
    public void RevealItem()
    {
        if (item != null && !isRevealed)
        {
            item.SetActive(true);  // Make item visible
            isRevealed = true;     // Mark as revealed for this scene only
            Debug.Log($"Item revealed in the current scene.");
        }
    }

    // Optionally, a method to reset the item reveal (for testing or other purposes)
    public void ResetItemReveal()
    {
        if (item != null && isRevealed)
        {
            item.SetActive(false); // Hide the item again
            isRevealed = false;    // Mark as not revealed for this scene
            Debug.Log($"Item reveal reset in the current scene.");
        }
    }
}
