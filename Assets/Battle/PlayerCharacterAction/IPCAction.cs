public abstract class AbstractPCAction {
    abstract public void Act();
    abstract public void Update(float dt);

    protected PC pc;

    public void SetPC(PC pc)
    {
        this.pc = pc;
    }
}