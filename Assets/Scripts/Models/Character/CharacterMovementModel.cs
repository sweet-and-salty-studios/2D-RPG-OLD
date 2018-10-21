using UnityEngine;

public class CharacterMovementModel : MonoBehaviour
{
    private readonly float movementSpeed = 2f;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

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
        if(MovementDirection != Vector2.zero)
        {
            MovementDirection.Normalize();
        }

        rb2d.velocity = MovementDirection * movementSpeed;
    }
}
