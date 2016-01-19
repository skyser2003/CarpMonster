using UnityEngine;

class PCActionJump : AbstractPCAction {
    private bool jumpPossible;
    private float speed;
    private float gravity;

    override protected void ActionInner()
    {
        jumpPossible = false;
        speed = 10;
        gravity = 20;
    }

    override protected void UpdateInner(float dt)
    {
        speed -= gravity * dt;
        Debug.Log(speed);

        var delta = new Vector3(0, speed * dt, 0);
        var newPos = pc.transform.localPosition + delta;

        if (newPos.y <= 0) {
            newPos.y = 0;
            jumpPossible = true;
        }

        pc.transform.localPosition = newPos;
    }
}