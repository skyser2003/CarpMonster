using UnityEngine;

public class AttackableTarget : MonoBehaviour {
    public int Hp;

    public int Group { get; set; }
    public bool IsDead { get; private set; }

    private void Start()
    {
        IsDead = false;
    }

    public void ProcessAttack(int damage)
    {
        Hp -= damage;
        if (Hp <= 0) {
            Die();
        }
    }

    public void Die()
    {
        IsDead = true;
    }
}