using UnityEngine;

public class WatchTrigger : Behavior{
    private Rigidbody2D m_rb;

    public WatchTrigger(Rigidbody2D rb){
        m_rb = rb;
    }

    protected override EStatus OnUpdate(){
        if (Test0.watch || (Test0.haveHatred && !Test0.attack)){
            Test0.haveHatred = true;
            return EStatus.Success;
        }

        return EStatus.Failure;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder WatchTrigger(Rigidbody2D rb){
        var node = new WatchTrigger(rb);
        AddBehavior(node);
        return this;
    }
}