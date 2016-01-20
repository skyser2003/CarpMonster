using UnityEngine;

class WallEnemy : Enemy {
    private PC pc;
    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            ProcessDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var other = collider.gameObject;
        pc = other.GetComponent<PC>();
        if (pc != null) {
            pc.Moveable = false;
        }
    }

    private void ProcessDie()
    {
        Destroy(gameObject);
        Map.Instance.RemoveEnemy(this);
    }

    public override void SetPCAction(PC pc)
    {
        pc.SetAction(new PCActionCloseAttack());
    }

    public override void UnsetPCAction(PC pc)
    {
        pc.SetAction(new PCActionJump());
    }

    public override void ProcessAttack(int damage)
    {
        attackable.ProcessAttack(damage);
        if (attackable.IsDead == true && pc != null) {
            pc.Moveable = true;
        }
    }
}