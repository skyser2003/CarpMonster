using UnityEngine;

class PCActionCloseAttack : AbstractPCAction {
    private int damage;

    public PCActionCloseAttack()
    {
        this.damage = 10;
    }

    public PCActionCloseAttack(int damage)
    {
        this.damage = damage;
    }

    protected override void ActionInner()
    {
        var enemy = Map.Instance.FindClosest(pc.transform.localPosition, 1.5f);
        if (enemy == null) {
            return;
        }

        enemy.ProcessAttack(damage);
    }

    protected override void UpdateInner(float dt)
    {

    }
}