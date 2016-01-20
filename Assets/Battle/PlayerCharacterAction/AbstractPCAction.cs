public abstract class AbstractPCAction {
    abstract protected void ActionInner();
    abstract protected void UpdateInner(float dt);

    protected PC pc;

    public void SetPC(PC pc)
    {
        this.pc = pc;
    }

    public void Action()
    {
        ActionInner();
    }

    public void Update(float dt)
    {
        UpdateInner(dt);
    }
}