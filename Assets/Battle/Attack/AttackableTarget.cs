using UnityEngine;

class AttackableTarget : MonoBehaviour {
    private int hp;
    
    public bool IsDead { get; private set; }

    private void Start()
    {
        hp = 20;
        IsDead = false;
    }

    public void ProcessAttack(int damage)
    {
        hp -= damage;
        if(hp <= 0) {
            Die();
        }
    }

    public void Die()
    {
        IsDead = true;
    }
}