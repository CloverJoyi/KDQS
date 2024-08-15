using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTest : BehaviourBase
{
    private IPlayerBase m_playerBase;
    public BehaviourTest(PlayerBase playerBase)
    {
        m_playerBase = playerBase;

    }
    public override void Action(int actionID, bool execute = true)
    {
        switch (actionID)
        {
            case RequestID.Move:
                Avtion_Move(execute);
                break;
            case RequestID.Jump:
                Avtion_Jump(execute);
                break;
            case RequestID.Attack:
                Avtion_Attack(execute);
                break;
            case RequestID.Dash:
                Avtion_Sprint(execute);
                break;
            case RequestID.Down:
                Avtion_Down(execute);
                break;
            case RequestID.Shoot:
                Avtion_Shoot(execute);
                break;
            case RequestID.Hurted:
                Avtion_Hurted(execute);
                break;
            case RequestID.Died:
                Avtion_Died(execute);
                break;
        }
    }
    public override void ActionWithData(int actionID, params object[] data)
    {

    }

    public void Avtion_Move(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Move);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Move);
        }
    }

    public void Avtion_Jump(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Jump);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Jump);
        }
    }

    public void Avtion_Sprint(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Dash);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Dash);
        }
    }



    public void Avtion_Attack(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Attack);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Attack);
        }
    }

    public void Avtion_Down(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Down);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Down);
        }
    }

    public void Avtion_Shoot(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Shoot);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Shoot);
        }
    }

    public void Avtion_Hurted(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Hurted);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Hurted);
        }
    }

    public void Avtion_Died(bool execute)
    {
        if (execute)
        {
            BehaviourStateBase.ExecuteRequest(RequestID.Hurted);
        }
        else
        {
            BehaviourStateBase.CancelExecuteRequest(RequestID.Hurted);
        }
    }

}

