using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInvokerTest : InvokerBase
{
    public AIInvokerTest(RequestReceiverBase receiver) : base(receiver)
    {
        m_commandList.Add((int)AICallID.Idle);
        m_commandList.Add((int)AICallID.Attack);
        m_commandList.Add((int)AICallID.Track);
        m_commandList.Add((int)AICallID.Skill);
        m_commandList.Add((int)AICallID.Died);
    }

    public override void Call(int callID)
    {
        Debug.Log("顺利接受到指令ID:" + callID);
        SendRequest(callID);
    }

    private void SendRequest(int callID)
    {
        if (m_commandList.Contains(callID))
        {
            m_receiver.ReceiverRequest(CommandRequestMapping(callID));
        }
    }

    private int CommandRequestMapping(int callID)
    {
        switch (callID)
        {
            case (int)AICallID.Track:
                return AIRequestID.Track;
            case (int)AICallID.Attack:
                return AIRequestID.Attack;
            case (int)AICallID.Skill:
                return AIRequestID.Skill;
            case (int)AICallID.Died:
                return AIRequestID.Died;
        }
        return AIRequestID.Idle;
    }


}
public enum AICallID
{
    Idle = 1,
    Attack = 2,
    Track = 3,
    Skill = 4,
    Died = 5,

}