public class HitableBush : Hitable
{
    public override void OnHit(ItemType itemType)
    {
        base.OnHit(itemType);

        collider2D.enabled = false;

        if (!animator.enabled)
        {
            animator.enabled = true;
        }

        animator.SetTrigger("Destroy");
    }
}
