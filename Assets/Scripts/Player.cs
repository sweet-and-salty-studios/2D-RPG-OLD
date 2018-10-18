using UnityEngine;

public class Player : Character
{
	private const string HORIZONTAL_AXIS = "Horizontal";
	private const string VERTICAL_AXIS = "Vertical";

	[SerializeField]
	private LayerMask hitLayer;

	private readonly float angle = 0f;

	[SerializeField]
	private Vector2 directionInputs = Vector2.zero;

	protected override void Awake()
	{
		base.Awake();
	}

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
			var hits = Physics2D.OverlapBoxAll(Vector2.right * 6, Vector2.one, angle, hitLayer);
			foreach (var hit in hits)
			{
				print(hit.name);
			}
		}
	}
}
