using UnityEngine;

abstract public class Enemy : MonoBehaviour {
    abstract public void SetPCAction(PC pc);
    abstract public void UnsetPCAction(PC pc);
    abstract public void ProcessAttack(int damage);

    protected AttackableTarget attackable;

    public int ID { get; set; }

    protected virtual void Start()
    {
        attackable = GetComponent<AttackableTarget>();
    }
}