using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private bool playerInRange = false;  // Track if the player is in range
    public Dialogue dialogueScript;  // Reference to the Dialogue script on the NPC
    public Sprite requiredItem;
    [TextArea] public string successMessage = "Thanks for bringing the item!";
    [TextArea] public string failMessage = "You don't have what I need.";
    

    void Update()
    {
        // Check for player input (e.g., pressing 'E' to interact)
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueScript != null)
            {
                

                // First, check if the player has the required item
                if (InventoryManager.Instance.HasItem(requiredItem))
                {
                    // Player has the required item, give it to the NPC
                    InventoryManager.Instance.RemoveItem(requiredItem);
                    dialogueScript.StartDialogue(successMessage); // Show success message
                }
                else
                {
                    // Player doesn't have the required item, show alternative message
                    dialogueScript.StartDialogue(failMessage); // Show alternative message
                }


            }
            else
            {
                Debug.LogError("Dialogue script is not assigned!");
            }
        }
    }

    // When the player enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;  // Player is within range to interact
        }
    }

    // When the player leaves the trigger area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;  // Player is no longer in range to interact
        }
    }
}
