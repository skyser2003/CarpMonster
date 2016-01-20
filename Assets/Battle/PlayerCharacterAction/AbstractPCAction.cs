public abstract class AbstractPCAction {
    abstract protected void ActionInner();
    abstract protected void UpdateInner(float dt);

    private bool doUpdate = false;
    protected PC pc;

    public void SetPC(PC pc)
    {
        this.pc = pc;
    }

    public void Action()
    {
        ActionInner();
        doUpdate = true;
    }

    public void Update(float dt)
    {
        if (doUpdate == true) {
            UpdateInner(dt);
        }
    }
}