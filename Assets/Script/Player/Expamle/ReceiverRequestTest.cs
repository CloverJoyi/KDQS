

public class ReceiverRequestTest : RequestReceiverBase
{
    private IPlayerBase m_player;

    public ReceiverRequestTest(RequestHandlerBase requestHandler, BehaviourBase behaviour, IPlayerBase player) : base(requestHandler, behaviour)
    {
        m_player = player;
        //初始化dic
        RequestConditionInit();
    }

    private void RequestConditionInit()
    {
        StateHandlerBase playerStateHandler = m_player.stateHandler;

        //m_requestDic.Add(RequestID.Idle, new RequestNode(m_behaviour, RequestID.Idle, 1, playerStateHandler.GetStateCondition(RequestID.Idle)));
        m_requestDic.Add(RequestID.Move, new RequestNode(m_behaviour, RequestID.Move, 1, playerStateHandler.GetStateCondition(RequestID.Move)));
        m_requestDic.Add(RequestID.Jump, new RequestNode(m_behaviour, RequestID.Jump, 1, playerStateHandler.GetStateCondition(RequestID.Jump)));//请求通过的条件写在此处,依靠状态机判定
        m_requestDic.Add(RequestID.Attack, new RequestNode(m_behaviour, RequestID.Attack, 1, playerStateHandler.GetStateCondition(RequestID.Attack)));
        m_requestDic.Add(RequestID.Dash, new RequestNode(m_behaviour, RequestID.Dash, 1, playerStateHandler.GetStateCondition(RequestID.Dash)));
        m_requestDic.Add(RequestID.Down, new RequestNode(m_behaviour, RequestID.Down, 1, playerStateHandler.GetStateCondition(RequestID.Down)));
        m_requestDic.Add(RequestID.Shoot, new RequestNode(m_behaviour, RequestID.Shoot, 1, playerStateHandler.GetStateCondition(RequestID.Shoot)));
        m_requestDic.Add(RequestID.Hurted, new RequestNode(m_behaviour, RequestID.Hurted, 1, playerStateHandler.GetStateCondition(RequestID.Hurted)));
        m_requestDic.Add(RequestID.Died, new RequestNode(m_behaviour, RequestID.Died, 1, playerStateHandler.GetStateCondition(RequestID.Died)));
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

public class RequestID
{
    public const int Idle = 1;
    public const int Move = 2;
    public const int Jump = 3;
    public const int Attack = 4;
    public const int Dash = 5;
    public const int Down = 6;
    public const int Shoot = 7;
    public const int Hurted = 8;
    public const int Died = 9;
}



