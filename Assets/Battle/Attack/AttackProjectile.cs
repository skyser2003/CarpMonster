using UnityEngine;

class AttackProjectile : MonoBehaviour {
    private int group;

    private float speed;
    private int damage;

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;
        var delta = new Vector3(dt * speed, 0, 0);
        transform.localPosition += delta;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var other = collider.gameObject;
        var attackable = other.GetComponent<AttackableTarget>();
        if (attackable != null && attackable.Group != group) {
            attackable.ProcessAttack(damage);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void Init(int group, float speed, int damage)
    {
        this.group = group;
        this.speed = speed;
        this.damage = damage;
    }
}