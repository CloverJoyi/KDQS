//数据驱动
using System;
public enum RequestState
{
    back = 1,
    fore = 1 << 1,
    over = 1 << 2,//移位
}
public abstract class RequestBase
{
    public int actionID { get; protected set; }//行为ID(给下一层的)
    public int requestID { get; protected set; }//传入requestID是哪一个
    public Func<bool> exeCondition;
    protected RequestState m_requestState;//请求的状态
    protected BehaviourBase m_behavior;
    protected int m_requestLifeSteps;//请求的生命周期
    protected int m_requestCount;//生命周期计时器

    public RequestBase(BehaviourBase behaviour, int requestFlag, int lifeSteps, Func<bool> condition)
    {
        m_behavior = behaviour;
        actionID = requestFlag;
        m_requestLifeSteps = lifeSteps;
        exeCondition = condition;
    }

    protected abstract void OnRequestAction();
    protected abstract void OnRequestOver();

    public virtual bool RequestUpdate()
    {
        m_requestCount++;
        if (m_requestCount >= m_requestLifeSteps)
        {
            return true;
        }
        return false;
    }

    public void RequestAction()
    {
        m_requestCount = 0;
        OnRequestAction();
    }
    public void RequestOver()
    {
        m_requestCount = 0;
        OnRequestOver();
    }

    public virtual void ExternalInit(params object[] args)
    {

    }

}
