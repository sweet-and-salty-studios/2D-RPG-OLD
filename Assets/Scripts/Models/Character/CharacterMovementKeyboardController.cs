using UnityEngine;

public class CharacterMovementKeyboardController : BaseCharacterMovementController
{
    private Vector2 newDirection;

    private void Update()
    {
        UpdateDirection();
    }

    private void UpdateDirection()
    {
        newDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            newDirection.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newDirection.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newDirection.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newDirection.x = -1;
        }

        SetDirection(newDirection);
    }
}
