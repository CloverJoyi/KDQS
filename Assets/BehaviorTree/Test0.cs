using System;
using UnityEngine;

public class Test0 : MonoBehaviour{
    public Animator anim;
    public Rigidbody2D rb;
    public static bool haveHatred = false; //仇恨判断

    BehaviorTreeBuilder builder;


    private void Awake(){
        builder = new BehaviorTreeBuilder();
    }

    private void Start(){
        // builder.Repeat(3)
        //     .Sequence()
        //     .DebugNode("Ok,") //由于动作节点不进栈，所以不用Back
        //     .DebugNode("It's ")
        //     .DebugNode("My time")
        //     .Back()
        //     .End();
        // builder.TreeTick();
        BuildTree();
    }

    private void Update(){
        builder.TreeTick();
    }


    private void OnDrawGizmos(){
        ExploreAreaUtil.DrawWatchBox(rb);
        ExploreAreaUtil.DrawAttackBox(rb);
    }

    private void BuildTree(){
        builder.Seletctor()
            .Sequence()
            .DeidTrigger()
            .Died(anim, rb)
            .Back()
            .Sequence()
            .SkillTrigger()
            .ChangeDirection(rb)
            .Skill(anim, rb)
            .Back()
            .Sequence()
            .AttackTrigger(rb)
            .ChangeDirection(rb)
            .Attack(rb, anim)
            .Back()
            .Sequence()
            .WatchTrigger(rb)
            .ChangeDirection(rb)
            .Track(rb, anim)
            .ChangeDirection(rb)
            .Back()
            .Sequence()
            .Idle(anim)
            .Back()
            .End();
    }
}