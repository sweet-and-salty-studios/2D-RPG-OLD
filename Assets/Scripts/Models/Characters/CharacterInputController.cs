using UnityEngine;

public abstract class CharacterInputController : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        SetDirection(Vector2.down);
    }

    protected void SetDirection(Vector2 direction)
    {
        if (character.MovementModel == null || !character.CurrentCharacterState.Equals(CHARACTER_STATE.DEFAULT))
        {
            return;
        }

        character.MovementModel.SetDirection(direction);
    }

    protected void OnActionPressed()
    {
        if (character.InteractionModel == null || !character.CurrentCharacterState.Equals(CHARACTER_STATE.DEFAULT))
        {
            return;
        }

        character.InteractionModel.OnInteract();     
    }

    protected void OnAttackPressed()
    {
        if (character.MovementModel == null || !character.CurrentCharacterState.Equals(CHARACTER_STATE.DEFAULT))
        {
            return;
        }

        character.MovementModel.DoAttack();      
    }

    protected void OnRunPressed()
    {
        if (character.MovementModel == null || !character.CurrentCharacterState.Equals(CHARACTER_STATE.DEFAULT))
        {
            return;
        }

        character.MovementModel.Run();
    }
}
