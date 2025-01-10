using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedTrigger : Behavior{
    protected override EStatus OnUpdate(){
        if (BossHealth.health <= 0){
            return EStatus.Success;
        }

        return EStatus.Failure;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder DeidTrigger(){
        var node = new DiedTrigger();
        AddBehavior(node);
        return this;
    }
}