

using System.Collections.Generic;

public abstract class InvokerBase
{
    protected List<int> m_commandList;
    protected RequestReceiverBase m_receiver;
    public InvokerBase(RequestReceiverBase receiver)
    {
        m_receiver = receiver;
        m_commandList = new List<int>();
    }

    public abstract void Call(int callID);

    public void Update()
    {
        OnUpdate();
    }
    public void FixedUpdate()
    {
        OnFixedUpdate();
    }
    protected virtual void OnUpdate() { }
    protected virtual void OnFixedUpdate() { }
}
