using UnityEngine;

public class AttackTrigger : Behavior{
    private Rigidbody2D m_rb;

    public AttackTrigger(Rigidbody2D rb){
        m_rb = rb;
    }

    protected override EStatus OnUpdate(){
        if (Test0.attack){
            Test0.haveHatred = true;
            return EStatus.Success;
        }

        return EStatus.Failure;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder AttackTrigger(Rigidbody2D rb){
        var node = new AttackTrigger(rb);
        AddBehavior(node);
        return this;
    }
}