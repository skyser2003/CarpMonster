using UnityEngine;

public class PC : MonoBehaviour {
    private AbstractPCAction action;
    private AttackableTarget attackable;

    private void Start()
    {
        attackable = GetComponent<AttackableTarget>();
    }

    private void FixedUpdate()
    {
        if(attackable.IsDead == true) {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void SetAction(AbstractPCAction action)
    {
        this.action = action;
    }
}