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

    [Header("Persistent Item Reveal")]
    public GameObject itemToReveal;
    public string revealKey = "FishermanFailItemRevealed"; // Unique key for this item

    [Header("Required Managers")]
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ObjectiveManager objectiveManager;

    void Start()
    {
        if (inventoryManager == null)
            Debug.LogWarning("InventoryManager not assigned in Inspector.");
        if (objectiveManager == null)
            Debug.LogWarning("ObjectiveManager not assigned in Inspector.");

        // Reveal saved item if needed
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
                if (inventoryManager != null && inventoryManager.HasItem(requiredItem))
                {
                    inventoryManager.RemoveItem(requiredItem);
                    dialogueScript.StartDialogue(successMessage);
                    if (objectiveManager != null)
                        objectiveManager.RemoveObjective(objectiveMessage);
                }
                else
                {
                    dialogueScript.StartDialogue(failMessage);

                    if (itemToReveal != null && PlayerPrefs.GetInt(revealKey, 0) == 0)
                    {
                        itemToReveal.SetActive(true);
                        PlayerPrefs.SetInt(revealKey, 1);
                        PlayerPrefs.Save();
                    }
                }

                if (!objectiveGiven && !string.IsNullOrEmpty(objectiveMessage))
                {
                    if (objectiveManager != null)
                        objectiveManager.AddObjective(objectiveMessage);

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
