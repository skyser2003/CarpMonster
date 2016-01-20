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

        if (pc.transform.localPosition.y <= 0) {
            currentJumpCount = possibleJumpCount;
            pc.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Carp/Carp_stand");
        }
    }

    override protected void ActionInner()
    {
        if (currentJumpCount == 0) {
            return;
        }

        --currentJumpCount;
        pc.GetComponent<GravityObject>().Speed = 10;
        pc.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Carp/Carp_jump");
    }

    override protected void UpdateInner(float dt)
    {
        ResetJumpCount();
    }
}