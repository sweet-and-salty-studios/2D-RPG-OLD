using System.Collections;
using UnityEngine;

public class InteractableChest : BaseInteractable
{
    [SerializeField]
    private ItemType itemInChest;
    [SerializeField]
    private int itemAmount;

    private Coroutine openChest;
    private Animator animator;
    private bool isOpen;
    private readonly float waitOpenTime = 1f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public override void OnInteract(Character character)
    {
        base.OnInteract(character);
        OpenChest(character);
    }

    private void OpenChest(Character character)
    {
        if (openChest == null && !isOpen)
        {
            openChest = StartCoroutine(IOpenChest(character));
            GiveItem(character, itemAmount);
        }
    }

    private void GiveItem(Character character, int amount)
    {
        character.InventoryModel.AddItem(itemInChest, itemAmount);
    }

    private IEnumerator IOpenChest(Character character)
    {
        animator.SetTrigger("OpenChest");
        character.ChangeCharacterState(CHARACTER_STATE.INTERACT);

        yield return new WaitForSeconds(waitOpenTime);

        character.InteractionBubble.CloseInteractionBubble();
        character.ChangeCharacterState(CHARACTER_STATE.DEFAULT);
        isOpen = true;
        openChest = null;
    }
}
