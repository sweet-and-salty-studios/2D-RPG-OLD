﻿using UnityEngine;

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
        return (Vector2)character.Collider2D.bounds.center + (character.MovementModel.MovementDirection);
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
        interactablePoint = CalculateInteractablePoint();

        var interactableColliders = Physics2D.OverlapPointAll(interactablePoint, character.InteractableLayer);

        foreach (var targetInteractableCollider in interactableColliders)
        {
            Debug.Log(targetInteractableCollider.gameObject.name, gameObject);
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

        Gizmos.color = new Color(1, 0, 1, 0.5f);
        Gizmos.DrawCube((Vector2)transform.position + character.MovementModel.MovementDirection, Vector2.one * 0.5f);
    }
}