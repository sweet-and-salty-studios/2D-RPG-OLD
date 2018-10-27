using UnityEngine;
using UnityEngine.UI;

public class CharacterInteractionBubble : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bubbleSprites;
    private Image bubbleImage;
    private Text bubbleText;

    private void Awake()
    {
        bubbleImage = GetComponent<Image>();
        bubbleText = GetComponentInChildren<Text>();
    }

    /// <summary>
    ///  Bubble types: 0 = Think, 1 = Speak, 2 = Yell
    /// </summary>
    /// <param name="message"></param>
    /// <param name="bubbleType"></param>
    public void OpenInteractionBubble(string message, int bubbleType)
    {
        bubbleImage.sprite = bubbleSprites[bubbleType];
        bubbleText.text = message;
        bubbleImage.enabled = true;
        bubbleText.enabled = true;
    }

    public void CloseInteractionBubble()
    {
        bubbleImage.enabled = false;
        bubbleText.enabled = false;
    }
}
