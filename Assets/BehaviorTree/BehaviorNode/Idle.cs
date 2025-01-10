using UnityEngine;

public class Idle : Behavior{
    private Animator m_anim;

    public Idle(Animator anim){
        m_anim = anim;
    }

    protected override EStatus OnUpdate(){
        //if (!Test0.haveHatred){
        m_anim.Play("Idle");
        return EStatus.Success;
        //}

        //return EStatus.Failure;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder Idle(Animator anim){
        var node = new Idle(anim);
        AddBehavior(node);
        return this;
    }
}