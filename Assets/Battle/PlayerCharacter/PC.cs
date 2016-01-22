using System;
using UnityEngine;

public class PC : MonoBehaviour {
    private AbstractPCAction action;
    private AttackableTarget attackable;

    private float moveSpeed;

    public bool Moveable { get; set; }

    virtual protected void Start()
    {
        attackable = GetComponent<AttackableTarget>();
        attackable.Group = 0;

        moveSpeed = 3;
        Moveable = true;
        SetAction(new PCActionJump());
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            ProcessDie();
        }

        if (Moveable == true) {
            var moveDelta = new Vector3(moveSpeed * dt, 0, 0);
            transform.localPosition += moveDelta;
        }

        action.Update(dt);
    }

    private void ProcessDie()
    {
        transform.localPosition = new Vector3(-1000, -1000, -1000);
        gameObject.SetActive(false);
    }

    public void SetAction(AbstractPCAction action)
    {
        this.action = action;
        action.SetPC(this);
    }

    public Type GetActionType()
    {
        return action.GetType();
    }

    public void Action()
    {
        if (action != null) {
            action.Action();
        }
    }
}