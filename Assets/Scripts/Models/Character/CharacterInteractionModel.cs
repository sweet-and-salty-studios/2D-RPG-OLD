using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
    private Vector2 InteractPoint = Vector2.one;
    private LayerMask interactableLayer;

    private void Start()
    {
        interactableLayer = LayerMask.GetMask("Interactable");
    }

    public void OnInteract()
    {
        var hits = Physics2D.OverlapBoxAll(InteractPoint, Vector2.one,1f);
        Debug.Log(hits.Length);
        foreach (var hit in hits)
        {
            Debug.Log(hit.name);
        }
    }
}
