using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI; // Reference to the inventory UI (Canvas or Panel)
    private bool isInventoryVisible = false;  // Track whether inventory is visible

    void Update()
    {
        // Toggle inventory visibility when the "I" key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;  
        inventoryUI.SetActive(isInventoryVisible); 
    }
}
