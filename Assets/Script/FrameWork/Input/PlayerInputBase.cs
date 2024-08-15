
public class InputData
{

}

public class PlayerInputBase
{
    protected InvokerBase m_invoker;
    protected InputData m_inputData;
    protected PlayerHealth m_health;

    public PlayerInputBase(InvokerBase invoker, PlayerHealth health)
    {
        m_invoker = invoker;
        m_health = health;
    }

    public void Update()
    {
        GetInputAxis();
        CallCommand();
        EndOfUpdate();
    }
    public void FixedUpdate()
    {
        FixedCallCommand();
    }

    protected virtual void GetInputAxis() { }
    protected virtual void EndOfUpdate() { }
    protected virtual void FixedCallCommand() { }
    protected virtual void CallCommand() { }

    public T GetInputData<T>() where T : InputData, new()
    {
        if (m_inputData == null)
            m_inputData = new T();
        return (T)m_inputData;
    }

}
