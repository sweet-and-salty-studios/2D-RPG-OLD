using UnityEngine;

public abstract class BaseCharacterMovementController : MonoBehaviour
{
    private CharacterMovementModel characterMovementModel;

    private void Awake()
    {
        characterMovementModel = GetComponent<CharacterMovementModel>();
    }

    protected void SetDirection(Vector2 direction)
    {
        characterMovementModel.SetDirection(direction);
    }
}
