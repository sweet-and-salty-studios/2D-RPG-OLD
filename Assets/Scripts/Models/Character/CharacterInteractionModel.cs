using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
    private List<Interactable> interactables = new List<Interactable>();

    public void OnInteract()
    {
        for (int i = 0; i < interactables.Count; i++)
        {
            Debug.Log("Interactables: " + ( i + 1 ) + " " + interactables[i].name);
        }   
    }

    private Interactable FindUsableInteractable()
    {
        for (int i = 0; i < interactables.Count; i++)
        {
            float distanceToInteractable = Vector2.Distance(transform.position, interactables[i].transform.position);

            Debug.Log("Interactables: " + (i + 1) + " " + interactables[i].name + " " + distanceToInteractable);
        }

        return null;
    }

    public void RegisterInteractable(Interactable newInteractable)
    {
        if (interactables.Contains(newInteractable))
        {
            return;
        }

        Debug.Log("Interactable has registered: " + newInteractable.name, newInteractable);
        interactables.Add(newInteractable);
    }
    public void UnregisterInteractable(Interactable oldInteractable)
    {
        Debug.Log("Interactable has removed: " + oldInteractable.name, oldInteractable);
        interactables.Remove(oldInteractable);
    }
}
