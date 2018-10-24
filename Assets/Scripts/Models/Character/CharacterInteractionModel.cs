using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
    private Character character;

    private Vector2 interactablePoint = Vector2.zero;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        interactablePoint = CalculateInteractablePoint();
    }

    private Vector2 CalculateInteractablePoint()
    {
        return (Vector2)character.Collider2D.bounds.center + (character.MovementModel.FaceDirection * 0.5f);
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

        var interactableColliders = Physics2D.OverlapPointAll(interactablePoint, character.InteractableLayer);

        foreach (var targetInteractableCollider in interactableColliders)
        {
            Debug.Log(targetInteractableCollider.gameObject.name, gameObject);
            return targetInteractableCollider.GetComponent<BaseInteractable>();
        }

        return null;
    }

    //private void OnDrawGizmos()
    //{
    //    if (!UnityEditor.EditorApplication.isPlaying)
    //    {
    //        return;
    //    }

    //    if ((!Input.GetKey(KeyCode.Space) || character.MovementModel.IsMoving) && foo)
    //    {
    //        return;
    //    }
        
    //    Gizmos.color = Color.blue;
    //    float size = 0.2f;

    //    Gizmos.DrawLine(interactablePoint - Vector2.up * size, interactablePoint + Vector2.up * size);
    //    Gizmos.DrawLine(interactablePoint - Vector2.left * size, interactablePoint + Vector2.left * size);      
    //}
}
