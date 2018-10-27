using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    private readonly string mainCharacterTag = "Player";
    
    [SerializeField]
    private Vector2 newMaxPosition;
    [SerializeField]
    private Vector2 newMinPosition;
    [SerializeField]
    private Vector2 newCharacterPlacement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(mainCharacterTag))
        {
            CameraEngine.Instance.MinPosition = newMaxPosition;
            CameraEngine.Instance.MaxPosition = newMinPosition;
            CameraEngine.Instance.transform.position = newMinPosition;
            other.transform.position += (Vector3)newCharacterPlacement;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
