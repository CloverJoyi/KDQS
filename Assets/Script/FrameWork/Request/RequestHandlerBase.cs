using System.Collections.Generic;
using UnityEngine;

public abstract class RequestHandlerBase
{
    protected Queue<RequestBase> m_foreRequestQueue;//前端队列
    protected Queue<RequestBase> m_backRequestQueue;//后端队列
    protected BehaviourBase m_behaviour;
    public RequestHandlerBase(BehaviourBase behaviour)
    {
        m_behaviour = behaviour;
        m_foreRequestQueue = new Queue<RequestBase>();
        m_backRequestQueue = new Queue<RequestBase>();
    }

    public abstract void ReceiveRequest(RequestBase request);//接受请求

    protected virtual void OnUpdate()
    {

    }

    protected virtual void OnFixedUpdate()
    {

    }

    //前端队列入队和出队
    protected void EnqueueFore(RequestBase request)
    {
        m_foreRequestQueue.Enqueue(request);
    }

    protected RequestBase DequeueFore()
    {
        return m_foreRequestQueue.Dequeue();
    }

    //后端队列入队和出队
    protected void EnqueueBack(RequestBase request)
    {
        m_foreRequestQueue.Enqueue(request);
    }

    protected RequestBase DequeueBack()
    {
        return m_foreRequestQueue.Dequeue();
    }


    public void Update()
    {
        OnUpdate();
    }

    public void FixedUpdate()
    {
        OnFixedUpdate();
    }

}
