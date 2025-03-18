using UnityEngine;

public class ObjectiveSystem : MonoBehaviour
{
    // Reference to the UI Panel (the objective system)
    public GameObject objectivePanel;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the objective panel is hidden at the start
        objectivePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the 'O' key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Toggle the visibility of the objective panel
            bool isActive = objectivePanel.activeSelf;
            objectivePanel.SetActive(!isActive);
        }
    }
}
