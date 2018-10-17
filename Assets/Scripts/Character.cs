using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 4f;
    protected Vector2 moveDirection;
    [SerializeField]
    protected Vector2 lastMoveDirection;
    [SerializeField]
    private bool isMoving;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        Movement(moveDirection);
    }

    private void Movement(Vector2 moveDirection)
    {
        isMoving = false;
        isMoving = moveDirection != Vector2.zero ? true : false;
        animator.SetBool("IsMoving", isMoving);

        if (isMoving)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            animator.SetFloat("X", moveDirection.x);
            animator.SetFloat("Y", moveDirection.y);
        }
        else
        {
            lastMoveDirection = moveDirection;
            animator.SetFloat("Last X", lastMoveDirection.x);
            animator.SetFloat("Last Y", lastMoveDirection.y);
        }
    }
}
