using UnityEngine;

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

    [Header("Item Reveal On Fail")]
    public GameObject itemToReveal; // Item to show when player fails
    private bool itemRevealedOnFail = false;

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

                    // ✅ Only reveal the item once during fail
                    if (!itemRevealedOnFail && itemToReveal != null)
                    {
                        itemToReveal.SetActive(true);
                        itemRevealedOnFail = true;
                    }
                }

                // Prevents repeating the same objective
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
