using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{
    private Character character;
    private Animator animator;

	private void Awake ()
    {
        character = GetComponent<Character>();
        animator = GetComponentInChildren<Animator>();
	}

    private void Update()
    {
        UpdateDirectionAnimation();
    }

    private void UpdateDirectionAnimation()
    {
        Vector2 direction = character.MovementModel.MovementDirection;

        if(direction != Vector2.zero)
        {
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionY", direction.y);
        }

        animator.SetBool("IsMoving", character.MovementModel.IsMoving);
    }

    public void AnimateAttack()
    {
        animator.SetTrigger("Attack");
    }
}
