using UnityEngine;

public class InteractableChest : BaseInteractable
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OpenChest()
    {
        animator.SetTrigger("Open");
    }

    public override void OnInteract()
    {
        base.OnInteract();
        OpenChest();
    }
}
