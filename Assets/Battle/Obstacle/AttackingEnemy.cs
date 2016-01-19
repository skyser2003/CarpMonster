using UnityEngine;

class AttackingEnemy : Enemy {
    private int damage = 10;
    private float attackSpeed = 1.0f;
    private float attackDelay = 1.0f;

    override protected void Start()
    {
        base.Start();

        hp = 10;
        Group = 1;
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (IsDead == true) {
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
        projectile.Init(Group, new Vector2(-3, 0), damage);
    }
}