using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : ScriptableObject
{
    [SerializeField]
    private List<ItemData> data;

    public ItemData FindItemData(ItemType itemType)
    {
        for (int i = 0; i < data.Count; ++i)
        {
            if (data[i].itemType.Equals(itemType))
            {
                return data[i];
            }
        }

        Debug.LogError("Item type: " + itemType + " not found in data");
        return null;
    }
}

[System.Serializable]
public class ItemData
{
    public ItemType itemType;
    public GameObject itemPrefab;
    public bool IsEquippable;
}
