using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    private float knockbackRate;
    private int damage;
    private int hp;
    
    private float framePerKnockback;
    private float remainKnockback;

    // Use this for initialization
    void Start () {
	
	}


    private void FixedUpdate()
    {
        if(remainKnockback > 0)
        {
            remainKnockback -= framePerKnockback;

            remainKnockback = remainKnockback > 0 ? remainKnockback : 0;
        }
    }
    
	// Update is called once per frame
	void Update () {
	
	}

    //붕어의 공격액션을 당했을때 반응
    public void attacked(int damage)
    {
        hp -= damage;
        if (hp < 0)
            Destroy();
        else
            knockback();
    }

    //붕어와 충돌시 반응
    public void collision()
    {
        knockback();
    }

    private void knockback()
    {
        remainKnockback = knockbackRate;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
