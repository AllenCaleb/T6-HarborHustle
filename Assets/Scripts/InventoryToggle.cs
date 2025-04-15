using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject UI_Inventory;
    private bool isOpen = false;

    void Start()
    {
        if (UI_Inventory != null)
        {
            UI_Inventory.SetActive(false); // Explicitly hide on start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        if (UI_Inventory == null)
        {
            Debug.LogWarning("UI_Inventory has been destroyed or is missing.");
            return;
        }

        isOpen = !isOpen;
        UI_Inventory.SetActive(isOpen);
    }

}
