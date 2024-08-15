using UnityEngine;

public class ExploreData
{

}

public class ExploreInputBase
{
    protected ExploreData m_exploreData;
    protected InvokerBase m_invoker;

    public ExploreInputBase(InvokerBase invoker, Rigidbody2D rb, BossHealth health)
    {
        m_invoker = invoker;
    }

    public void Update()
    {
        GetExplore();
        CallCommand();
        EndOfUpdate();
    }
    public void FixedUpdate()
    {
        FixedCallCommand();
    }

    protected virtual void GetExplore() { }
    protected virtual void EndOfUpdate() { }
    protected virtual void FixedCallCommand() { }
    protected virtual void CallCommand() { }


    public T GetExploreData<T>() where T : ExploreData, new()
    {
        if (m_exploreData == null)
            m_exploreData = new T();
        return (T)m_exploreData;
    }


}
