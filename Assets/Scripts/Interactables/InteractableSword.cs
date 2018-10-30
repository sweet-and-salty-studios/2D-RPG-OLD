using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSword : BaseInteractable
{
    private ItemType weaponType;

    private void Awake()
    {
        weaponType = ItemType.SWORD;
    }

    public override void OnInteract(Character character)
    {
        base.OnInteract(character);

        GiveItem(character, weaponType, 1);

        Destroy(gameObject);
    }

    protected override void GiveItem(Character character, ItemType weaponType, int amount)
    {
        character.InventoryModel.AddItem(weaponType, amount);
    }
}
