using UnityEngine;

class AttackingEnemy : Enemy {
    private float attackSpeed = 0;
    private float attackDelay;

    public int Damage { get; private set; }

    protected override void Start()
    {
        base.Start();

        attackable.hp = 20;
        attackable.Group = 1;

        attackDelay = attackSpeed;
        Damage = 10;
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            ProcessDie();
        }

        if (attackSpeed > 0) {
            attackDelay -= dt;
            if (attackDelay <= 0) {
                attackDelay += attackSpeed;
                Attack();
            }
        }
    }

    private void Attack()
    {
        var obj = Instantiate(Resources.Load("bullet")) as GameObject;
        obj.transform.localPosition = transform.localPosition;

        var projectile = obj.GetComponent<AttackProjectile>();
        projectile.Init(attackable.Group, new Vector2(-3, 0), Damage);
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