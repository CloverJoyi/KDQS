
public abstract class BehaviourBase
{
    public BehaviourBase()
    {

    }
    public abstract void Action(int actionID, bool execute = true);
    public abstract void ActionWithData(int actionID, params object[] data);
}
