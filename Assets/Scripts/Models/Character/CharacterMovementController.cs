using System.Collections;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    private Character character;

    private Coroutine attackCoroutine;
    private readonly float attackDuration = 0.4f;

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

        if (attackCoroutine == null)
        {
            StartCoroutine(IAttack(attackDuration));
        }    
    }

    private IEnumerator IAttack(float attackDuration)
    {
        character.ChangeCharacterState(CHARACTER_STATE.ATTACK);

        character.MovementModel.OnAttack();
        character.MovementView.AnimateAttack();

        yield return new WaitForSeconds(attackDuration);

        character.ChangeCharacterState(CHARACTER_STATE.DEFAULT);
        attackCoroutine = null;
    }
}
