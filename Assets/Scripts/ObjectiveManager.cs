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
            objectiveText.text = "Objectives:\n";
            foreach (var obj in objectives)
            {
                objectiveText.text += "• " + obj + "\n";
            }
        }
    }

    public void ClearAllObjectives()
    {
        objectives.Clear();
        UpdateObjectiveText();
    }
}
