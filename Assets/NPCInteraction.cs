using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    public Dialogue dialogueScript;
    public Sprite requiredItem;

    [Header("Dialogue Messages")]
    [TextArea] public string successMessage = "Thanks for bringing the item!";
    [TextArea] public string failMessage = "You don't have what I need.";
    [TextArea] public string objectiveMessage = "Collect 3 Fish for the fisherman.";

    private bool objectiveGiven = false;

    [Header("Persistent Item Reveal")]
    public GameObject itemToReveal;
    public string revealKey = "FishermanFailItemRevealed"; // Unique key for this item

    void Start()
    {
        // Check if the item should already be revealed when the scene loads
        if (!string.IsNullOrEmpty(revealKey) && PlayerPrefs.GetInt(revealKey, 0) == 1)
        {
            if (itemToReveal != null)
                itemToReveal.SetActive(true);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueScript != null)
            {
                if (InventoryManager.Instance.HasItem(requiredItem))
                {
                    // Remove the required item from the inventory
                    InventoryManager.Instance.RemoveItem(requiredItem);

                    // Start the success dialogue
                    dialogueScript.StartDialogue(successMessage);

                    // Remove the objective after it's completed
                    ObjectiveManager.Instance.RemoveObjective(objectiveMessage);
                }
                else
                {
                    // Start the fail dialogue
                    dialogueScript.StartDialogue(failMessage);

                    // Only reveal the item once
                    if (itemToReveal != null && PlayerPrefs.GetInt(revealKey, 0) == 0)
                    {
                        itemToReveal.SetActive(true);
                        PlayerPrefs.SetInt(revealKey, 1); // Save that the item was revealed
                        PlayerPrefs.Save(); // Ensure it's written to disk
                    }
                }

                // Add the objective if it hasn't been added already
                if (!objectiveGiven && !string.IsNullOrEmpty(objectiveMessage))
                {
                    ObjectiveManager.Instance.AddObjective(objectiveMessage);
                    objectiveGiven = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
