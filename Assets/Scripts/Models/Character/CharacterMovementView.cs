using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{
    private CharacterMovementModel characterMovementModel;
    private Animator animator;

	private void Awake ()
    {
        characterMovementModel = GetComponent<CharacterMovementModel>();
        animator = GetComponentInChildren<Animator>();
	}

    private void Update()
    {
        UpdateDirectionAnimation();
    }

    private void UpdateDirectionAnimation()
    {
        Vector2 direction = characterMovementModel.MovementDirection;

        if(direction != Vector2.zero)
        {
            animator.SetFloat("DirectionX", direction.x);
            animator.SetFloat("DirectionY", direction.y);
        }

        animator.SetBool("IsMoving", characterMovementModel.IsMoving);
    }
}
