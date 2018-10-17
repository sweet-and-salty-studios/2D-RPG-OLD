using UnityEngine;

public class Player : Character
{
	private const string HORIZONTAL_AXIS = "Horizontal";
	private const string VERTICAL_AXIS = "Vertical";

	[SerializeField]
	private Vector2 directionInputs = Vector2.zero;

	protected override void Update ()
	{
		moveDirection = GetInputDirection();

		base.Update();
	}

	private Vector2 GetInputDirection()
	{
		directionInputs = new Vector2(Input.GetAxisRaw(HORIZONTAL_AXIS), Input.GetAxisRaw(VERTICAL_AXIS));
		directionInputs.Normalize();
		return directionInputs;
	}
}
