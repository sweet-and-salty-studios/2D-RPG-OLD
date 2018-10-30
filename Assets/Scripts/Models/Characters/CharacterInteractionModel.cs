using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void OnInteract()
    {
        var usableInteractable = FindInteractable();

        if (usableInteractable == null)
        {
            return;
        }

        usableInteractable.OnInteract(character);
    }

    private BaseInteractable FindInteractable()
    {
        var interactableColliders = Physics2D.OverlapBoxAll((Vector2)transform.position + character.MovementModel.FaceDirection, Vector2.one , 0f, character.InteractableLayer);

        foreach (var targetInteractableCollider in interactableColliders)
        {
            //Debug.Log(targetInteractableCollider.gameObject.name, gameObject);
            return targetInteractableCollider.GetComponent<BaseInteractable>();
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        if (!UnityEditor.EditorApplication.isPlaying)
        {
            return;
        }

        if (!InputManager.Instance.ActionButton)
        {
            return;
        }

        Gizmos.color = new Color(1, 0, 1, 0.5f);
        Gizmos.DrawCube((Vector2)transform.position + character.MovementModel.FaceDirection, Vector2.one );
    }
}
