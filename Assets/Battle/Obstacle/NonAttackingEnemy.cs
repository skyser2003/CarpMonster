using UnityEngine;

class NonAttackingEnemy : Enemy {
    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;
    }

    public override void SetPCAction(PC pc)
    {
        pc.SetAction(new PCActionCloseAttack());
    }

    public override void UnsetPCAction(PC pc)
    {
        pc.SetAction(new PCActionJump());
    }
}