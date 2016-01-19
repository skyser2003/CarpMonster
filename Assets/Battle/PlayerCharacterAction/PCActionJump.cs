using UnityEngine;

class PCActionJump : AbstractPCAction {
    private int possibleJumpCount = 1;
    private int currentJumpCount;
    private float speed;
    private float gravity;

    public PCActionJump()
    {
        currentJumpCount = possibleJumpCount;
    }

    override protected void ActionInner()
    {
        if (currentJumpCount == 0) {
            return;
        }

        --currentJumpCount;
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
            currentJumpCount = possibleJumpCount;
        }

        pc.transform.localPosition = newPos;
    }
}