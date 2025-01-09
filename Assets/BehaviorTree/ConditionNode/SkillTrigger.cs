using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTrigger : Behavior{
    protected override EStatus OnUpdate(){
        if (Attack.attackCount >= 3){
            Attack.attackCount = 0;
            return EStatus.Success;
        }

        return EStatus.Failure;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder SkillTrigger(){
        var node = new SkillTrigger();
        AddBehavior(node);
        return this;
    }
}