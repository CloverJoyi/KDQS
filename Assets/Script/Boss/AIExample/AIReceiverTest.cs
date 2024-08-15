
using UnityEngine;

public class AIReceiverTest : RequestReceiverBase
{
    private IAIBase m_ai;
    public AIReceiverTest(RequestHandlerBase requestHandler, BehaviourBase behaviour, IAIBase ai) : base(requestHandler, behaviour)
    {
        m_ai = ai;
        //初始化dic
        RequestConditionInit();
    }
    private void RequestConditionInit()
    {

        StateHandlerBase AIStateHandler = m_ai.stateHandler;

        //m_requestDic.Add(AIRequestID.Idle, new RequestNode(m_behaviour, AIRequestID.Idle, 1, AIStateHandler.GetStateCondition(AIRequestID.Idle)));
        m_requestDic.Add(AIRequestID.Attack, new RequestNode(m_behaviour, AIRequestID.Attack, 1, AIStateHandler.GetStateCondition(AIRequestID.Attack)));
        m_requestDic.Add(AIRequestID.Skill, new RequestNode(m_behaviour, AIRequestID.Skill, 1, AIStateHandler.GetStateCondition(AIRequestID.Skill)));
        m_requestDic.Add(AIRequestID.Track, new RequestNode(m_behaviour, AIRequestID.Track, 1, AIStateHandler.GetStateCondition(AIRequestID.Track)));
        m_requestDic.Add(AIRequestID.Died, new RequestNode(m_behaviour, AIRequestID.Died, 1, AIStateHandler.GetStateCondition(AIRequestID.Died)));

    }

    public override void ReceiverRequest(int requestID)
    {
        if (m_requestDic.TryGetValue(requestID, out var value))
        {
            m_requestHandler.ReceiveRequest(value);
        }


    }
    public override void ReceiverRequestWithData(int requestID, params object[] data)
    {
        if (m_requestDic.TryGetValue(requestID, out var value))
        {
            m_requestDic[requestID].ExternalInit(value);
            m_requestHandler.ReceiveRequest(value);
        }
    }
}

public class AIRequestID
{
    public const int Idle = 1;
    public const int Attack = 2;
    public const int Track = 3;
    public const int Skill = 4;
    public const int Died = 5;
}
