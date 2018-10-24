using System.Collections;
using UnityEngine;

public class InteractableSign : BaseInteractable
{
    private Coroutine toolTip = null;
    private readonly string description = "This is a sign \nnew line \nFoo!?";

    public override void OnInteract(Character character)
    {
        base.OnInteract(character);
        if(toolTip == null)
        {
            toolTip = StartCoroutine(IStartTooltip(character));
        }
    }

    private IEnumerator IStartTooltip(Character character)
    {
        character.ChangeCharacterState(CHARACTER_STATE.INTERACT);
        character.InteractionBubble.OpenInteractionBubble(description, 0);

        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));

        character.InteractionBubble.CloseInteractionBubble();
        character.ChangeCharacterState(CHARACTER_STATE.DEFAULT);

        toolTip = null;        
    }
}
