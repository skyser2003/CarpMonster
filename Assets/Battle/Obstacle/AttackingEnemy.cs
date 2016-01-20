using UnityEngine;

class AttackingEnemy : Enemy {
    private float attackDelay;
    private PC pc;

    public float AttackSpeed;
    public int RangeDamage;
    public int CloseDamage;
    public bool IsWall;
    public bool GetKnockBacked;

    protected override void Start()
    {
        base.Start();

        attackable.hp = 20;
        attackable.Group = 1;
        pc = GameObject.Find("Carp").GetComponent<PC>();

        attackDelay = AttackSpeed;
    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

        if (attackable.IsDead == true) {
            ProcessDie();
            return;
        }

        if (AttackSpeed > 0) {
            attackDelay -= dt;
            if (attackDelay <= 0) {
                attackDelay += AttackSpeed;
                RangeAttack();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var other = collider.gameObject;
        if (other.GetComponent<PC>() != null) {
            if (IsWall == true) {
                pc.Moveable = false;
            }

            CloseAttack();
        }
    }

    private void RangeAttack()
    {
        if (RangeDamage == 0) {
            return;
        }

        var obj = Instantiate(Resources.Load("bullet")) as GameObject;
        obj.transform.localPosition = transform.localPosition;

        var projectile = obj.GetComponent<AttackProjectile>();
        projectile.Init(attackable.Group, new Vector2(-3, 0), RangeDamage);
    }

    private void CloseAttack()
    {
        if (CloseDamage == 0) {
            return;
        }

        pc.GetComponent<AttackableTarget>().ProcessAttack(CloseDamage);
    }

    private void KnockBack()
    {
        if (GetKnockBacked == false) {
            return;
        }

        transform.localPosition += new Vector3(1, 0, 0);
    }

    private void ProcessDie()
    {
        Destroy(gameObject);
        Map.Instance.RemoveEnemy(this);
    }

    public override void ProcessAttack(int damage)
    {
        attackable.ProcessAttack(damage);

        if (attackable.IsDead == false) {
            KnockBack();
        }
        else if (IsWall == true) {
            pc.Moveable = true;
        }
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