using UnityEngine;

public class PC : AttackableTarget {
    private AbstractPCAction action;

    private float moveSpeed;
    private int damage;

    private void Start()
    {
        hp = 20;
        Group = 0;

        moveSpeed = 1;
        damage = 10;
        SetAction(new PCActionJump());
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (IsDead == true) {
            ProcessDie();
        }

        var moveDelta = new Vector3(moveSpeed * dt, 0, 0);
        transform.localPosition += moveDelta;

        action.Update(dt);
    }

    private void ProcessDie()
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