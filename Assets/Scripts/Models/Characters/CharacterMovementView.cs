using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{
    private Character character;
    private Animator animator;
    private Transform graphics;

    private void Awake ()
    {
        character = GetComponent<Character>();
        animator = GetComponentInChildren<Animator>();
        graphics = transform.Find("Graphics");
    }


    private void Update()
    {
        UpdateDirectionAnimation();
    }

    private void UpdateDirectionAnimation()
    {
        var direction = character.MovementModel.MovementDirection;

        if(direction != Vector2.zero)
        {
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionY", direction.y);
            graphics.localScale = new Vector2((direction.x > 0 ? -1 : 1), 1);     
        }

        animator.SetBool("IsMoving", character.MovementModel.IsMoving);
    }

    public void AnimateAttack()
    {
        animator.SetTrigger("Attack");
    }
}
