using UnityEngine;

public class PlayerInputController : CharacterInputController
{
    private Vector2 newDirection;

    private void Update()
    {
        UpdateDirection();
        UpdateAction();
        UpdateAttack();
    }

    private void UpdateAction()
    {
        if (Input.GetButton("Jump"))
        {
            OnActionPressed();
        }
    }

    private void UpdateAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnAttackPressed();
        }
    }

    private void UpdateDirection()
    {
        newDirection = Vector2.zero;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            newDirection.x = 1;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            newDirection.x = -1;
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            newDirection.y = 1;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            newDirection.y = -1;
        }

        SetDirection(newDirection);
    }
}
