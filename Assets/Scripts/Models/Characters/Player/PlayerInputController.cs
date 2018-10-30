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
        if (InputManager.Instance.ActionButtonDown)
        {
            OnActionPressed();
        }
    }

    private void UpdateAttack()
    {
        if (InputManager.Instance.AttackButtonDown)
        {
            OnAttackPressed();
        }
    }

    private void UpdateDirection()
    {
        newDirection = Vector2.zero;

        if (InputManager.Instance.HorizontalAxis > 0)
        {
            newDirection.x = 1;
        }
        if (InputManager.Instance.HorizontalAxis < 0)
        {
            newDirection.x = -1;
        }
        if (InputManager.Instance.VerticalAxis > 0)
        {
            newDirection.y = 1;
        }
        if (InputManager.Instance.VerticalAxis < 0)
        {
            newDirection.y = -1;
        }

        if (InputManager.Instance.RunButton)
        {
            OnRunPressed();
        }

        SetDirection(newDirection);
    }
}
