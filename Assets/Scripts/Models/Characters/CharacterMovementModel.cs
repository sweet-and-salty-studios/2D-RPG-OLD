using System.Collections;
using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
    private Character character;
    private float moveSpeed;
    private readonly float walkSpeed = 3f;
    private readonly float runSpeed = 6f;
    private Rigidbody2D rb2d;

    private Coroutine attackCoroutine, runCoroutine, pickUpCoroutine;
    private readonly float attackDuration = 0.5f;
    private readonly float pickUpTime = 2f;

    public Vector2 MovementDirection
    {
        get;
        private set;
    }
    public Vector2 FaceDirection
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
    public bool IsAttacking
    {
        get;
        private set;
    }
    public bool IsRunning { get; private set; }
    public bool CanAttack
    {
        get
        {
            return EquippedWeapon != ItemType.NONE && !IsAttacking ? true : false;
        }
    }
    public ItemType EquippedWeapon
    {
        get;
        private set;
    }
    public ItemType CurrentPickingUpObject { get; private set; }

    private void Awake()
    {
        character = GetComponent<Character>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    public void EquipWeapon(ItemData itemData)
    {
        if(itemData.itemType != ItemType.SWORD)
        {
            return;
        }

        EquippedWeapon = itemData.itemType;

        CreateNewWeapon(itemData);

        CurrentPickingUpObject = itemData.itemType;

        PickUpObject();
    }

    private void PickUpObject()
    {
        if(pickUpCoroutine == null)
        {
            StartCoroutine(IPickUp(pickUpTime));
        }
    }

    private void CreateNewWeapon(ItemData itemData)
    {
        var newWeaponPrefab = itemData.itemPrefab;
        var newWeapon = Instantiate(newWeaponPrefab, character.MovementView.WeaponPivot).transform;
        newWeapon.localPosition = Vector2.zero;
        newWeapon.localRotation = Quaternion.identity;
        newWeapon.name = newWeaponPrefab.name;
    }

    public void SetDirection(Vector2 direction)
    {
        MovementDirection = new Vector2(direction.x, direction.y);

        if(direction != Vector2.zero)
        {
            FaceDirection = MovementDirection;
        }
    }

    public void Run()
    {
        if (runCoroutine == null && !IsRunning)
        {
            StartCoroutine(IRun());
        }
    }

    private void UpdateMovement()
    {
        if (MovementDirection != Vector2.zero)
        {
            MovementDirection.Normalize();
        }

        rb2d.velocity = MovementDirection * moveSpeed;
    }

    public void DoAttack()
    {
        if (attackCoroutine == null && CanAttack)
        {
            StartCoroutine(IAttack(attackDuration));
        }
    }

    public void SearchAttackHits()
    {
        var hitColliders = Physics2D.OverlapBoxAll((Vector2)transform.position + FaceDirection, Vector2.one * 0.5f, 0f, character.InteractableLayer);

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

    private IEnumerator IPickUp(float pickUpTime)
    {
        character.ChangeCharacterState(CHARACTER_STATE.INTERACT);
        character.MovementView.UpdateAnimatePickUp(true);

        yield return new WaitForSeconds(pickUpTime);

        character.ChangeCharacterState(CHARACTER_STATE.DEFAULT);
        character.MovementView.UpdateAnimatePickUp(false);
    }

    private IEnumerator IRun()
    {
        IsRunning = true;

        moveSpeed = runSpeed;

        yield return new WaitWhile(() => InputManager.Instance.RunButtonUp);

        moveSpeed = walkSpeed;
        IsRunning = false;
        runCoroutine = null;
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
        Gizmos.DrawCube((Vector2)transform.position + FaceDirection , Vector2.one * 0.5f);
    }
}
