using UnityEngine;

public class Chest : Interactable
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
}
