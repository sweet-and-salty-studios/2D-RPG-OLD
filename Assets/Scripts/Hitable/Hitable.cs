using UnityEngine;

public abstract class Hitable : MonoBehaviour
{
    protected Animator animator;
    protected new Collider2D collider2D;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        animator.enabled = false;
    }

    public virtual void OnHit(ItemType itemType)
    {
        
    }
}
