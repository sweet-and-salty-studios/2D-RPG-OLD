using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
    private Vector2 interactablePoint = Vector2.zero;
    private LayerMask interactableLayer;
    private CharacterMovementModel characterMovementModel;
    private new Collider2D collider2D;

    private void Awake()
    {
        interactableLayer = LayerMask.GetMask("Interactable");
        characterMovementModel = GetComponent<CharacterMovementModel>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        interactablePoint = CalculateInteractablePoint();
    }

    private Vector2 CalculateInteractablePoint()
    {
        return (Vector2)collider2D.bounds.center + (characterMovementModel.FaceDirection);
    }

    public void OnInteract()
    {
        var usableInteractable = FindInteractable();

        if(usableInteractable == null)
        {
            return;
        }

        usableInteractable.OnInteract();
    }

    private BaseInteractable FindInteractable()
    {
        interactablePoint = CalculateInteractablePoint();

        var interactableColliders = Physics2D.OverlapPointAll(interactablePoint, interactableLayer);

        foreach (var targetInteractableCollider in interactableColliders)
        {
            Debug.Log(targetInteractableCollider.gameObject.name, gameObject);
            var interactable = targetInteractableCollider.GetComponent<BaseInteractable>();
            return interactable;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float size = 0.2f;

        Gizmos.DrawLine(interactablePoint - Vector2.up * size, interactablePoint + Vector2.up * size);
        Gizmos.DrawLine(interactablePoint - Vector2.left * size, interactablePoint + Vector2.left * size);
            
    }
}
