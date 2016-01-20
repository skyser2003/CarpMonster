using UnityEngine;

abstract public class Enemy : MonoBehaviour {
    abstract public void SetPCAction(PC pc);
    abstract public void UnsetPCAction(PC pc);
    abstract public void ProcessAttack(int damage);

    protected AttackableTarget attackable;

    protected virtual void Start()
    {
        Map.Instance.AddEnemy(this);
        attackable = GetComponent<AttackableTarget>();
    }
}