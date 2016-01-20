using UnityEngine;

class HurdleEnemy : Enemy {
    public int Damage;

    private void CloseAttack()
    {
        if (Damage == 0) {
            return;
        }

        var pc = GameObject.Find("Carp");
        pc.GetComponent<AttackableTarget>().ProcessAttack(Damage);
    }

    public override void ProcessAttack(int damage)
    {
    }

    public override void SetPCAction(PC pc)
    {
        pc.SetAction(new PCActionJump());
    }

    public override void UnsetPCAction(PC pc)
    {
        pc.SetAction(new PCActionJump());
    }
}