using UnityEngine;

class AttackingEnemy : MonoBehaviour {
    private int damage = 10;
    private float attackSpeed = 1.0f;
    private float attackDelay = 1.0f;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;

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
        projectile.Init(new Vector2(-1, 0), damage);
    }
}