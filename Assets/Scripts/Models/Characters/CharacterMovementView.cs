using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{
    private Character character;

    public Animator Animator
    {
        get;
        private set;
    }
    public Transform Graphics
    {
        get;
        private set;
    }
    public Transform WeaponPivot
    {
        get;
        private set;
    }

    private void Awake ()
    {
        character = GetComponent<Character>();
        Animator = GetComponentInChildren<Animator>();
        Graphics = transform.Find("Graphics");
        WeaponPivot = Graphics.transform.Find("WeaponPivot");
        WeaponPivot.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateDirectionAnimation();
    }

    private void UpdateDirectionAnimation()
    {
        var direction = character.MovementModel.MovementDirection;

        if(direction != Vector2.zero)
        {
            Animator.SetFloat("DirectionX", direction.x);
            Animator.SetFloat("DirectionY", direction.y);
            Graphics.localScale = new Vector2((direction.x > 0 ? -1 : 1), 1);     
        }

            Animator.SetBool("IsMoving", character.MovementModel.IsMoving);
    }

    public void AnimateAttack()
    {
        Animator.SetTrigger("Attack");
    }

    public void UpdateAnimatePickUp(bool isPickingUp)
    {       
        Animator.SetBool("IsPickingUp", isPickingUp);
    }
}
