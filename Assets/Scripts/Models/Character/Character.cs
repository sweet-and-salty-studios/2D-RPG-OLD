using UnityEngine;

public class Character : MonoBehaviour
{
    public Collider2D Collider2D { get; private set; }

    public CHARACTER_STATE CurrentCharacterState { get; private set; }
    public CharacterMovementModel MovementModel { get; private set; }
    public CharacterInteractionModel InteractionModel { get; private set; }
    public CharacterInventoryModel InventoryModel { get; private set; }
    public CharacterMovementView MovementView { get; private set; }

    public CharacterInteractionBubble InteractionBubble { get; private set; }

    public LayerMask InteractableLayer { get; private set; }
    //public LayerMask AttackableLayer { get; private set; }

    public ItemType CurrentWeapon { get; private set; }

    protected virtual void Awake()
    {
        Collider2D = GetComponent<Collider2D>();

        MovementModel = GetComponent<CharacterMovementModel>();
        InteractionModel = GetComponent<CharacterInteractionModel>();
        InventoryModel = GetComponent<CharacterInventoryModel>();
        MovementView = GetComponent<CharacterMovementView>();

        InteractionBubble = transform.GetChild(0).GetComponentInChildren<CharacterInteractionBubble>();

        InteractableLayer = LayerMask.GetMask("Interactable");
    }

    private void Start()
    {
        InteractionBubble.CloseInteractionBubble();

        CurrentWeapon = ItemType.SWORD;
    }

    public void ChangeCharacterState(CHARACTER_STATE newCharacterState)
    {
        CurrentCharacterState = newCharacterState;

        switch (CurrentCharacterState)
        {
            case CHARACTER_STATE.DEFAULT:
                break;

            case CHARACTER_STATE.ATTACK:
                MovementModel.SetDirection(Vector2.zero);
                break;

            case CHARACTER_STATE.INTERACT:
                MovementModel.SetDirection(Vector2.zero);
                break;

            case CHARACTER_STATE.DIALOG:
                break;

            default:
                CurrentCharacterState = CHARACTER_STATE.DEFAULT;
                break;
        }
    }
}
