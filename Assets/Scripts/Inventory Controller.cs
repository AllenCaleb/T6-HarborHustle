using UnityEngine;

public class InventoryController : MonoBehaviour
{
    // Reference to the Canvas or parent GameObject of your inventory
    public GameObject UI_Inventory;

    void Update()
    {
        // Listen for the "I" key press
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle the visibility of the inventory UI (Canvas or object)
            UI_Inventory.SetActive(!UI_Inventory.activeSelf);
        }
    }
}
