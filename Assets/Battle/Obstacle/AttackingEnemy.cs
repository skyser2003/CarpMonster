using UnityEngine;

class AttackingEnemy : Enemy {
    private int damage = 10;
    private float attackSpeed = 3.0f;
    private float attackDelay;

    protected override void Start()
    {
        base.Start();

        attackable.hp = 10;
        attackable.Group = 1;

        attackDelay = attackSpeed;
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            ProcessDie();
        }

        attackDelay -= dt;
        if (attackDelay <= 0) {
            attackDelay += attackSpeed;
            Attack();
        }
    }

    private void Attack()
    {
        var obj = Instantiate(Resources.Load("bullet")) as GameObject;
        obj.transform.localPosition = transform.localPosition;

        var projectile = obj.GetComponent<AttackProjectile>();
        projectile.Init(attackable.Group, new Vector2(-3, 0), damage);
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