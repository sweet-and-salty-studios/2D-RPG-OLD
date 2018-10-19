using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2f;

    public Vector2 MovementDirection
    {
        get;
        private set;
    }

    public bool IsMoving
    {
        get
        {
            return MovementDirection != Vector2.zero ? true : false; 
        }
    }

    private void Update()
    {
        UpdateMovement();
    }

    public void SetDirection(Vector2 direction)
    {
        MovementDirection = new Vector3(direction.x, direction.y, 0);
    }

    private void UpdateMovement()
    {
        if(MovementDirection == Vector2.zero)
        {
            return;
        }

        MovementDirection.Normalize();

        transform.Translate(MovementDirection * movementSpeed * Time.deltaTime);
    }
}
