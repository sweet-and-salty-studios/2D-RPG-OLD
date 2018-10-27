using System.Collections;
using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
    private Character character;
    private readonly float movementSpeed = 3f;
    private Rigidbody2D rb2d;

    private Coroutine attackCoroutine;
    private readonly float attackDuration = 0.4f;

    public bool IsAttacking
    {
        get;
        private set;
    }
    // public bool CanAttack { get; private set; }

    private void Awake()
    {
        character = GetComponent<Character>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public Vector2 MovementDirection
    {
        get;
        private set;
    }

    public bool IsMoving
    {
        get
        {
            return MovementDirection != Vector2.zero ? true : false; 
        }
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    public void SetDirection(Vector2 direction)
    {
        MovementDirection = new Vector2(direction.x, direction.y);
    }

    private void UpdateMovement()
    {
        if (MovementDirection != Vector2.zero)
        {
            MovementDirection.Normalize();
        }

        rb2d.velocity = MovementDirection * movementSpeed;
    }

    public void DoAttack()
    {
        if (attackCoroutine == null)
        {
            StartCoroutine(IAttack(attackDuration));
        }
    }

    public void SearchAttackHits()
    {
        var hitColliders = Physics2D.OverlapBoxAll((Vector2)transform.position + MovementDirection * 0.5f, Vector2.one * 0.5f, 0f, character.InteractableLayer);

        if (hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                var hitable = hitCollider.GetComponent<Hitable>();

                if(hitable == null)
                {
                    continue;
                }

                hitable.OnHit(character.CurrentWeapon);
            }
        }
    }

    private IEnumerator IAttack(float attackDuration)
    {
        IsAttacking = true;
        character.ChangeCharacterState(CHARACTER_STATE.ATTACK);

        SearchAttackHits();
        character.MovementView.AnimateAttack();

        yield return new WaitForSeconds(attackDuration);

        character.ChangeCharacterState(CHARACTER_STATE.DEFAULT);
        IsAttacking = false;
        attackCoroutine = null;
    }

    private void OnDrawGizmos()
    {
        if (!UnityEditor.EditorApplication.isPlaying)
        {
            return;
        }

        if (!IsAttacking)
        {
            return;
        }

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube((Vector2)transform.position + MovementDirection * 0.5f , Vector2.one * 0.5f);
    }
}
