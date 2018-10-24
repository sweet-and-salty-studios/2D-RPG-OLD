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

    public Vector2 FaceDirection
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

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    public void SetDirection(Vector2 direction)
    {
        MovementDirection = new Vector2(direction.x, direction.y);

        if(direction != Vector2.zero)
        {
            FaceDirection = direction;
        }
    }

    private void UpdateMovement()
    {
        if (MovementDirection != Vector2.zero)
        {
            MovementDirection.Normalize();
        }

        rb2d.velocity = MovementDirection * movementSpeed;
    }

    public void OnAttack()
    {
        var hitColliders = Physics2D.OverlapBoxAll((Vector2)transform.position + FaceDirection, Vector2.one / 2, 1f);

        if(hitColliders.Length > 0)
        {
            foreach (var hitCollider in hitColliders)
            {
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube((Vector2)transform.position + FaceDirection * 0.5f , Vector2.one * 0.5f);
    }
}
