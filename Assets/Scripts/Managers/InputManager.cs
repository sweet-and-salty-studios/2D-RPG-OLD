using UnityEngine;

public class InputManager : Singelton<InputManager>
{
    private const string HORIZONTAL_MOVEMENT_AXIS = "Horizontal";
    private const string VERTICAL_MOVEMENT_AXIS = "Vertical";

    public float HorizontalAxis
    {
        get
        {
            return Input.GetAxisRaw(HORIZONTAL_MOVEMENT_AXIS);
        }
    }
    public float VerticalAxis
    {
        get
        {
            return Input.GetAxisRaw(VERTICAL_MOVEMENT_AXIS);
        }
    }

    public bool ActionButtonDown
    {
        get
        {
            return Input.GetButtonDown("Action");
        }
    }
    public bool ActionButton
    {
        get
        {
            return Input.GetButton("Action");
        }
    }
    public bool ActionButtonUp
    {
        get
        {
            return Input.GetButtonUp("Action");
        }
    }

    public bool AttackButtonDown
    {
        get
        {
            return Input.GetButtonDown("Attack");
        }
    }
    public bool AttackButton
    {
        get
        {
            return Input.GetButton("Attack");
        }
    }
    public bool AttackButtonUp
    {
        get
        {
            return Input.GetButtonUp("Attack");
        }
    }

    public bool RunButtonDown { get { return Input.GetButtonDown("Run"); } }
    public bool RunButton { get { return Input.GetButtonDown("Run"); } }
    public bool RunButtonUp { get { return Input.GetButtonDown("Run"); } }
}
