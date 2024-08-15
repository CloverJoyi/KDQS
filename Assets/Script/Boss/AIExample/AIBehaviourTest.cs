public class AIBehaviourTest : BehaviourBase
{
    private IAIBase m_aiBase;
    public AIBehaviourTest(AIBase aiBase)
    {
        m_aiBase = aiBase;

    }
    public override void Action(int actionID, bool execute = true)
    {
        switch (actionID)
        {
            case AIRequestID.Track:
                Avtion_Track(execute);
                break;
            case AIRequestID.Attack:
                Avtion_Attack(execute);
                break;
            case AIRequestID.Died:
                Avtion_Died(execute);
                break;

        }
    }
    public override void ActionWithData(int actionID, params object[] data)
    {

    }

    public void Avtion_Track(bool execute)
    {
        if (execute)
        {
            AIBehaviourStateBase.ExecuteRequest(AIRequestID.Track);
        }
        else
        {
            AIBehaviourStateBase.CancelExecuteRequest(AIRequestID.Track);
        }
    }

    public void Avtion_Attack(bool execute)
    {
        if (execute)
        {
            AIBehaviourStateBase.ExecuteRequest(AIRequestID.Attack);
        }
        else
        {
            AIBehaviourStateBase.CancelExecuteRequest(AIRequestID.Attack);
        }
    }

    public void Avtion_Died(bool execute)
    {
        if (execute)
        {
            AIBehaviourStateBase.ExecuteRequest(AIRequestID.Died);
        }
        else
        {
            AIBehaviourStateBase.CancelExecuteRequest(AIRequestID.Died);
        }
    }

}