using UnityEngine;

public class Player : Character
{
	private const string HORIZONTAL_AXIS = "Horizontal";
	private const string VERTICAL_AXIS = "Vertical";

    [SerializeField]
    private LayerMask hitLayer;
    [SerializeField]
    private GameObject slashEffectPrefab;

    private readonly float angle = 0f;

    [SerializeField]
	private Vector2 directionInputs = Vector2.zero;

    private void Update ()
	{
        Attack();
        moveDirection = GetInputDirection();
	}

    private Vector2 GetInputDirection()
	{
		directionInputs = new Vector2(Input.GetAxisRaw(HORIZONTAL_AXIS), Input.GetAxisRaw(VERTICAL_AXIS));
		directionInputs.Normalize();
		return directionInputs;
	}

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(slashEffectPrefab, lastMoveDirection, Quaternion.identity);

            var hits = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, transform.position.y + 6), Vector2.one, angle, hitLayer);
            foreach (var hit in hits)
            {
                print(hit.name);
            }
        }
    }
}
