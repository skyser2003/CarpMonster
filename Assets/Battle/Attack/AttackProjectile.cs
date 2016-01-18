using UnityEngine;

class AttackProjectile : MonoBehaviour {
    private Vector2 velocity;
    private int damage;

    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime;
        Vector3 delta = dt * velocity;
        transform.localPosition += delta;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var other = collider.gameObject;
        var attackable = other.GetComponent<AttackableTarget>();
        if (attackable != null) {
            attackable.ProcessAttack(damage);
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public void Init(Vector2 velocity, int damage)
    {
        this.velocity = velocity;
        this.damage = damage;
    }
}