using UnityEngine;

class PCActionJump : AbstractPCAction {
    private int possibleJumpCount = 1;
    private int currentJumpCount;

    public PCActionJump()
    {
        ResetJumpCount();
    }

    private void ResetJumpCount()
    {
        var pc = GameObject.Find("Carp");

        if (pc.GetComponent<GravityObject>().Speed <= 0 && pc.transform.localPosition.y <= 0 && currentJumpCount != possibleJumpCount) {
            currentJumpCount = possibleJumpCount;
        }
    }

    override protected void ActionInner()
    {
        if (currentJumpCount == 0) {
            return;
        }

        --currentJumpCount;
        pc.GetComponent<GravityObject>().Speed = 10;
    }

    override protected void UpdateInner(float dt)
    {
        ResetJumpCount();
    }
}