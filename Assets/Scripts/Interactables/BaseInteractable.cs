using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour
{
    public virtual void OnInteract(Character character)
    {
        
    }

    protected virtual void GiveItem(Character character, ItemType itemType, int amount)
    {
        character.InventoryModel.AddItem(itemType, amount);
    }
}
