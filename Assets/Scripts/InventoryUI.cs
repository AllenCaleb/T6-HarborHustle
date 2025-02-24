using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemSlotContainer;
    public GameObject itemSlotPrefab;

    public void UpdateInventoryUI(List<Item> items)
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in items)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotContainer);
            itemSlot.transform.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;
            itemSlot.transform.Find("ItemQuantity").GetComponent<Text>().text = item.quantity > 1 ? item.quantity.ToString() : "";
        }
    }
}
