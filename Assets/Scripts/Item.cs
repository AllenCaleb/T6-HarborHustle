using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Hat, Docs
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        if (ItemAssets.Instance == null)
        {
            Debug.LogError("ItemAssets Instance is null! Make sure it exists in the scene.");
            return null;
        }

        switch (itemType)
        {
            default:
            case ItemType.Hat: return ItemAssets.Instance.HatSprite;
            case ItemType.Docs: return ItemAssets.Instance.DocsSprite;
        }
    }
}