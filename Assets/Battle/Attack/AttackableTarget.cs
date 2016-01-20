using UnityEngine;

public class AttackableTarget : MonoBehaviour {
    public int hp;
    
    public int Group { get; set; }
    public bool IsDead { get; private set; }

    private void Start()
    {
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