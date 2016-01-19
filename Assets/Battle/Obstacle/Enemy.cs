using UnityEngine;

abstract public class Enemy : AttackableTarget {
    abstract public void UpdatePCAction(PC pc);

    virtual protected void Start()
    {

    }

    protected void ProcessDie()
    {
        Destroy(gameObject);
    }
}