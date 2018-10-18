using UnityEngine;

public class Enemy : Character
{
    private enum ENEMY_STATE
    {
        IDLE,
        MOVE,
        ATTACK
    }

    private ENEMY_STATE currentEnemyState;

    [SerializeField]
    private LayerMask hitLayer;

    private Transform target;

    private readonly float angle = 0f;

    [SerializeField]
    private Vector2 directionInputs = Vector2.zero;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        Attack();
        moveDirection = GetInputDirection();
    }

    private Vector2 GetInputDirection()
    {
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

    private void ChangeEnemyState(ENEMY_STATE newEnemyState)
    {
        currentEnemyState = newEnemyState;

        switch (currentEnemyState)
        {
            case ENEMY_STATE.IDLE:

                break;
            case ENEMY_STATE.MOVE:

                break;
            case ENEMY_STATE.ATTACK:

                break;
            default:

                break;
        }
    }
}
