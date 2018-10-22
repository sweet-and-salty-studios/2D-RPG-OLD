using UnityEngine;

public abstract class BaseCharacterMovementController : MonoBehaviour
{
    private CharacterMovementModel characterMovementModel;
    private CharacterInteractionModel characterInteractionModel;

    private void Awake()
    {
        characterMovementModel = GetComponent<CharacterMovementModel>();
        characterInteractionModel = GetComponent<CharacterInteractionModel>();
    }

    protected void SetDirection(Vector2 direction)
    {
        if (characterMovementModel == null)
        {
            return;
        }

        characterMovementModel.SetDirection(direction);
    }

    protected void OnActionPressed()
    {
        if (characterInteractionModel == null)
        {
            return;
        }

        characterInteractionModel.OnInteract();
    }
}
