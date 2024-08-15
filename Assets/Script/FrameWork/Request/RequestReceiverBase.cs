using System.Collections.Generic;
using UnityEngine;
interface IRequestReceiver
{
    public void ReceiverRequest(int requestID);
}
public class RequestReceiverBase : IRequestReceiver
{
    protected Dictionary<int, RequestBase> m_requestDic;
    protected RequestHandlerBase m_requestHandler;
    protected BehaviourBase m_behaviour;

    public RequestReceiverBase(RequestHandlerBase requestHandler, BehaviourBase behaviour)
    {
        m_requestDic = new Dictionary<int, RequestBase>();
        m_requestHandler = requestHandler;
        m_behaviour = behaviour;
    }

    public virtual void ReceiverRequest(int requestID)
    {
        if (m_requestDic.ContainsKey(requestID))
        {
            //接受请求
        }
        else
        {
            Debug.Log("没有对应ID的请求,ID为" + requestID.ToString());
        }
    }

    public virtual void ReceiverRequestWithData(int requestID, params object[] data)
    {

    }

    //注册请求
    public void RegisterRequest(int requestID, RequestBase request)
    {
        if (m_requestDic.ContainsKey(requestID))
        {
            m_requestDic[requestID] = request;//覆盖
        }
        else
        {
            m_requestDic.Add(requestID, request);
        }
    }

    public void RemoveRequest(int requestID)
    {
        if (m_requestDic.ContainsKey(requestID))
        {
            m_requestDic.Remove(requestID);
        }
    }
}
