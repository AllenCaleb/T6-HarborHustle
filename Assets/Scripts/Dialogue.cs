using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isTyping = false; // Prevents multiple clicks during typing

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lines == null || lines.Length == 0)
            {
                Debug.LogError("Dialogue lines are empty or not assigned!");
                return;
            }

            if (index < 0 || index >= lines.Length)
            {
                Debug.LogError($"Index {index} is out of bounds! Lines length: {lines.Length}");
                return;
            }

            if (isTyping) // If typing is in progress, complete the line instantly
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                isTyping = false; // Reset flag after finishing
            }
            else // Otherwise, go to the next line
            {
                NextLine();
            }
        }
    }

    public void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogError("Dialogue lines are empty or not assigned!");
            lines = new string[] { "Default dialogue line." };
            return;
        }
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;  // Ensure text is cleared before starting typing
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;  // Mark typing as finished
    }

    void NextLine()
    {
        if (lines == null || lines.Length == 0)
        {
            Debug.LogError("Dialogue lines are empty or not assigned!");
            gameObject.SetActive(false);
            return;
        }

        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            Invoke("DeactivateDialogueBox", 19f);  // Set a short delay before deactivating
        }
    }

    void DeactivateDialogueBox()
    {
        gameObject.SetActive(false);
    }
}
