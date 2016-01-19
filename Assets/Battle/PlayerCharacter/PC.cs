using UnityEngine;

public class PC : MonoBehaviour {
    private AbstractPCAction action;
    private AttackableTarget attackable;
    private float moveSpeed = 1.0f;

    private void Start()
    {
        attackable = GetComponent<AttackableTarget>();
        SetAction(new PCActionJump());
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            Die();
        }

        var moveDelta = new Vector3(moveSpeed * dt, 0, 0);
        transform.localPosition += moveDelta;

        action.Update(dt);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void SetAction(AbstractPCAction action)
    {
        this.action = action;
        action.SetPC(this);
    }

    public void Action()
    {
        if (action != null) {
            action.Action();
        }
    }
}