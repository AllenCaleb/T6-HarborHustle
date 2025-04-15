using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;

    private List<string> objectives = new List<string>();
    private bool isVisible = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleObjectivePanel();
        }
    }

    public void AddObjective(string newObjective)
    {
        if (!objectives.Contains(newObjective)) // prevent duplicates
        {
            objectives.Add(newObjective);
            Debug.Log("Objective added: " + newObjective);

            // Only update if the panel is visible
            if (isVisible)
            {
                UpdateObjectiveText();
            }
        }
    }

    public void RemoveObjective(string objectiveToRemove)
    {
        if (objectives.Contains(objectiveToRemove))
        {
            objectives.Remove(objectiveToRemove);
            Debug.Log("Objective removed: " + objectiveToRemove);

            // Only update if the panel is visible
            if (isVisible)
            {
                UpdateObjectiveText();
            }
        }
    }

    private void ToggleObjectivePanel()
    {
        isVisible = !isVisible;

        if (objectivePanel != null)
        {
            objectivePanel.SetActive(isVisible);

            // Only update the text if the panel is being opened (avoiding redundant updates)
            if (isVisible)
            {
                UpdateObjectiveText();
            }
        }
    }

    private void UpdateObjectiveText()
    {
        if (objectiveText == null) return;

        if (objectives.Count == 0)
        {
            objectiveText.text = "No active objectives.";
        }
        else
        {
            // Use StringBuilder for more efficient text building
            var objectiveListText = new System.Text.StringBuilder("Objectives:\n");

            foreach (var obj in objectives)
            {
                objectiveListText.AppendLine("• " + obj);
            }

            objectiveText.text = objectiveListText.ToString();
        }
    }

    public void ClearAllObjectives()
    {
        objectives.Clear();
        UpdateObjectiveText(); // Updates the UI when all objectives are cleared
    }
}
