using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private bool playerInRange = false;  // Track if the player is in range
    public Dialogue dialogueScript;  // Reference to the Dialogue script on the NPC
    public Sprite requiredItem;
    [TextArea] public string successMessage = "Thanks for bringing the item!";
    [TextArea] public string failMessage = "You don't have what I need.";

    [TextArea] public string objectiveMessage = "Collect 3 Fish for the fisherman.";

    private bool objectiveGiven = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueScript != null)
            {
                if (InventoryManager.Instance.HasItem(requiredItem))
                {
                    InventoryManager.Instance.RemoveItem(requiredItem);
                    dialogueScript.StartDialogue(successMessage);
                    ObjectiveManager.Instance.RemoveObjective(objectiveMessage);

                }
                else
                {
                    dialogueScript.StartDialogue(failMessage);
                }

                

                // Prevents objective Spamming
                if (!objectiveGiven && !string.IsNullOrEmpty(objectiveMessage))
                {
                    ObjectiveManager.Instance.AddObjective(objectiveMessage);
                    objectiveGiven = true;
                }
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
