using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private void Start()
    {
        RegisterInteractable();
    }

    private void OnDestroy()
    {
        UnregisterInteractable();
    }

    private void RegisterInteractable()
    {
        var interactableModel = GetCharacterInteractionModel();

        if (interactableModel == null)
        {
            return;
        }

        interactableModel.RegisterInteractable(this);
    }
    private void UnregisterInteractable()
    {
        var interactableModel = GetCharacterInteractionModel();

        if(interactableModel == null)
        {
            return;
        }

        interactableModel.UnregisterInteractable(this);
    }
    private CharacterInteractionModel GetCharacterInteractionModel()
    {
        var mainCharacterObject = GameMaster.Instance.MainCharacter;
        if (mainCharacterObject == null)
        {
            Debug.LogWarning("Main character not found!");
            return null;
        }

        var mainCharacterInteractableModel = mainCharacterObject.GetComponent<CharacterInteractionModel>();
        if (mainCharacterInteractableModel == null)
        {
            Debug.LogWarning("Main character interactable model not found!");
            return null;
        }

        return mainCharacterInteractableModel;
    }
}
