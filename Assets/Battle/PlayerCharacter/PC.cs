using UnityEngine;

public class PC : MonoBehaviour {
    private AbstractPCAction action;
    private AttackableTarget attackable;

    private float moveSpeed;

    virtual protected void Start()
    {
        attackable = GetComponent<AttackableTarget>();
        attackable.hp = 100;
        attackable.Group = 0;

        moveSpeed = 1;
        SetAction(new PCActionJump());
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            ProcessDie();
        }

        var moveDelta = new Vector3(moveSpeed * dt, 0, 0);
        transform.localPosition += moveDelta;

        action.Update(dt);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var other = collider.gameObject;

        var enemy = other.GetComponent<AttackingEnemy>();
        if (enemy != null) {
            attackable.ProcessAttack(enemy.Damage);
        }
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

    public void Action()
    {
        if (action != null) {
            action.Action();
        }
    }
}