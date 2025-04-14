using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText; // Or use `Text` if not using TMP
    public float autoHideTime = 3f;      // Time before hiding dialogue
    private Queue<string> dialogueQueue = new Queue<string>();  // Queue to store dialogues
    private Coroutine hideRoutine;

    private void Start()
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    // Start dialogue with a message
    public void StartDialogue(string message)
    {
        if (dialoguePanel == null || dialogueText == null)
        {
            Debug.LogWarning("Dialogue panel or text is not assigned.");
            return;
        }

        // Add the new message to the queue
        dialogueQueue.Enqueue(message);

        // If the dialogue box is not already showing, start displaying it
        if (!dialoguePanel.activeSelf)
        {
            ShowNextMessage();
        }
    }

    // Display the next message in the queue
    private void ShowNextMessage()
    {
        if (dialogueQueue.Count > 0)
        {
            // Show the next message from the queue
            string nextMessage = dialogueQueue.Dequeue();
            dialogueText.text = nextMessage;
            dialoguePanel.SetActive(true);

            // Restart the hide timer
            if (hideRoutine != null)
                StopCoroutine(hideRoutine);

            hideRoutine = StartCoroutine(HideDialogueAfterDelay(autoHideTime));
        }
        else
        {
            // If no more messages are left, hide the panel
            dialoguePanel.SetActive(false);
        }
    }

    // Coroutine to hide the dialogue after a delay
    private IEnumerator HideDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowNextMessage();
    }
}
