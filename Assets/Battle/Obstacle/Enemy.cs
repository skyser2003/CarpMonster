using UnityEngine;

abstract public class Enemy : MonoBehaviour {
    abstract public void SetPCAction(PC pc);
    abstract public void UnsetPCAction(PC pc);

    protected AttackableTarget attackable;

    protected virtual void Start()
    {
        Map.Instance.AddEnemy(this);
        attackable = GetComponent<AttackableTarget>();
    }

    protected void ProcessDie()
    {
        Destroy(gameObject);
        Map.Instance.RemoveEnemy(this);
    }

    public void ProcessAttack(int damage)
    {
        attackable.ProcessAttack(damage);
    }
}