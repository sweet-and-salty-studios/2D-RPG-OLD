using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryModel : MonoBehaviour
{
    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    public void AddItem(ItemType itemType, int amount = 1)
    {
        if (items.ContainsKey(itemType))
        {
            items[itemType] += amount;
        }
        else
        {
            items.Add(itemType, amount);
        }
    }

    public void RemoveItem(ItemType itemType, int amount = 1)
    {
        if (items.ContainsKey(itemType))
        {
            items[itemType] -= amount;
        }
    }
}
