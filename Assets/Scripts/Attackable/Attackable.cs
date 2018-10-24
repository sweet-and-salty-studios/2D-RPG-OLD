using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected void OnHit(ItemType itemType)
    {
        
    }
}
