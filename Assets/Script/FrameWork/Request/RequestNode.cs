using System;
using UnityEngine;
public class RequestNode : RequestBase
{
    public RequestNode(BehaviourBase behaviour, int requestID, int lifeSteps, Func<bool> condition) : base(behaviour, requestID, lifeSteps, condition)
    {

    }

    //从这里传到行为层
    protected override void OnRequestAction()
    {
        //Debug.Log("请求执行行为：" + actionID);
        m_behavior.Action(actionID, true);
    }

    protected override void OnRequestOver()
    {
        m_behavior.Action(actionID, false);
    }
}
