using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    protected float moveSpeed = 4f;
    protected Vector2 moveDirection;
    [SerializeField]
    protected Vector2 lastMoveDirection;

    protected float maxHealth = 100f;
    protected float maxMana = 100f;

    protected float currentHealth;
    protected float currentMana;

    //private Animator animator;

    protected virtual void Awake()
    {
        //animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    protected virtual void FixedUpdate()
    {
        Movement(moveDirection);
    }

    private void Movement(Vector2 moveDirection)
    {
        if(moveDirection != Vector2.zero)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            //animator.SetFloat("X", moveDirection.x);
            //animator.SetFloat("Y", moveDirection.y);

            //animator.SetBool("IsMoving", true);
        }
        else
        {
            lastMoveDirection = moveDirection;
            //animator.SetFloat("Last X", lastMoveDirection.x);
            //animator.SetFloat("Last Y", lastMoveDirection.y);

            //animator.SetBool("IsMoving", false);
        }
    }
}
