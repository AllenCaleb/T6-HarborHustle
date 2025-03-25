using System.Collections;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    private bool playerInRange = false;  // Track if the player is in range
    public Dialogue dialogueScript;  // Reference to the Dialogue script on the NPC

    // Start is called before the first frame update
    void Start()
    {
        //// Make sure the dialogue is not showing at the start
        //if (dialogueScript != null)
        //{
        //    dialogueScript.gameObject.SetActive(false);  // Ensure the dialogue box is hidden initially
        //}
    }

    void Update()
    {
        // Check for player input (e.g., pressing 'E' to interact)
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogueScript != null)
            {
                dialogueScript.StartDialogue();  // Start the dialogue
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

