using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
    private Character character;

    private Vector2 interactablePoint = Vector2.zero;
    private LayerMask interactableLayer;
    private new Collider2D collider2D;

    private void Awake()
    {
        interactableLayer = LayerMask.GetMask("Interactable");
        character = GetComponent<Character>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        interactablePoint = CalculateInteractablePoint();
    }

    private Vector2 CalculateInteractablePoint()
    {
        return (Vector2)collider2D.bounds.center + (character.MovementModel.FaceDirection);
    }

    public void OnInteract()
    {
        var usableInteractable = FindInteractable();

        if(usableInteractable == null)
        {
            return;
        }

        usableInteractable.OnInteract(character);
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

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    float size = 0.2f;

    //    Gizmos.DrawLine(interactablePoint - Vector2.up * size, interactablePoint + Vector2.up * size);
    //    Gizmos.DrawLine(interactablePoint - Vector2.left * size, interactablePoint + Vector2.left * size);          
    //}
}
