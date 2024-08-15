using System;
using UnityEngine;

namespace Exaple
{
    public class InvokerTest : InvokerBase
    {
        public InvokerTest(RequestReceiverBase receiver) : base(receiver)
        {
            m_commandList.Add((int)CallID.Idle);
            m_commandList.Add((int)CallID.Move);
            m_commandList.Add((int)CallID.Jump);
            m_commandList.Add((int)CallID.Attack);
            m_commandList.Add((int)CallID.Sprint);
            m_commandList.Add((int)CallID.SkillDown);
            m_commandList.Add((int)CallID.Shoot);
            m_commandList.Add((int)CallID.Hurted);
        }

        public override void Call(int callID)
        {
            //Debug.Log("顺利接受到指令ID:" + callID);
            SendRequest(callID);
        }

        private void SendRequest(int callID)
        {
            if (m_commandList.Contains(callID))
            {
                m_receiver.ReceiverRequest(CommandRequestMapping(callID));
            }
        }

        //Invoker做的事情是接收指令，找出对应的请求ID，发送给Request层
        private int CommandRequestMapping(int callID)
        {
            switch (callID)
            {
                case (int)CallID.Idle:
                    return RequestID.Idle;
                case (int)CallID.Move:
                    return RequestID.Move;
                case (int)CallID.Jump:
                    return RequestID.Jump;
                case (int)CallID.Attack:
                    return RequestID.Attack;
                case (int)CallID.Sprint:
                    return RequestID.Dash;
                case (int)CallID.SkillDown:
                    return RequestID.Down;
                case (int)CallID.Shoot:
                    return RequestID.Shoot;
                case (int)CallID.Hurted:
                    return RequestID.Hurted;
                case (int)CallID.Died:
                    return RequestID.Died;
            }
            return RequestID.Idle;
        }
    }

    public enum CallID
    {
        Idle = 1,
        Move = 2,
        Jump = 3,
        Attack = 4,
        Sprint = 5,
        SkillDown = 6,
        Shoot = 7,
        Hurted = 8,
        Died = 9,

    }


}

