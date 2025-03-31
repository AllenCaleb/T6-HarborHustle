using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Transform inventoryUIParent; // Assign Inventory Grid in Inspector
    public GameObject inventoryItemPrefab; // Assign Inventory Item Prefab in Inspector

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void UpdateUI(Sprite itemSprite)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, inventoryUIParent);
        newItem.GetComponent<Image>().sprite = itemSprite; // Assign item image
    }
}
