using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryModel : MonoBehaviour
{
    private Character character;
    private Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();

    private void Awake()
    {
        character = GetComponent<Character>();
    }

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

        if(amount > 0)
        {
            var itemData = GameMaster.Instance.ItemDatabase.FindItemData(itemType);

            if (itemData.IsEquippable)
            {
                character.MovementModel.EquipWeapon(itemData);
            }
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
