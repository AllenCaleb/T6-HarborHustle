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
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    /* Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }*/
    private bool isTyping = false; // Prevents multiple clicks during typing

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

    void StartDialogue()
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
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
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
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
       else
        {
            Invoke("DeactivateDialogueBox", 6f);
        }
    }
    void DeactivateDialogueBox()
    {
        gameObject.SetActive(false);
    }
}