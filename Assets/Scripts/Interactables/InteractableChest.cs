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
    private bool isOpen = false;
    private readonly float interactTime = 1f;

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
        if (openChest == null)
        {          
            animator.SetBool("IsOpen", isOpen = !isOpen);
            openChest = StartCoroutine(IOpenChest(character));
            GiveItem(character, itemInChest, itemAmount);
        }
    }

    protected override void GiveItem(Character character,ItemType itemInChest, int amount)
    {
        character.InventoryModel.AddItem(itemInChest, itemAmount);
        itemAmount = 0;
    }

    private IEnumerator IOpenChest(Character character)
    {
        character.ChangeCharacterState(CHARACTER_STATE.INTERACT);

        yield return new WaitForSeconds(interactTime);

        character.InteractionBubble.CloseInteractionBubble();
        character.ChangeCharacterState(CHARACTER_STATE.DEFAULT);
        openChest = null;
    }
}
