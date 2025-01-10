using System;
using UnityEngine;

public class Test0 : MonoBehaviour{
    public Transform Pos1;
    public Transform Pos2;
    public Animator anim;

    private Rigidbody2D rb;
    BehaviorTreeBuilder builder;

    public static bool haveHatred = false; //仇恨判断

    private void Awake(){
        builder = new BehaviorTreeBuilder();
        rb = GetComponent<Rigidbody2D>();
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
            .Sequence()
            .SkillTrigger()
            .ChangeDirection(rb)
            .Skill(anim, rb)
            .Sequence()
            .AttackTrigger(rb)
            .ChangeDirection(rb)
            .Attack(rb, anim)
            .Sequence()
            .WatchTrigger(rb)
            .ChangeDirection(rb)
            .Track(rb, anim)
            .ChangeDirection(rb)
            .Sequence()
            .Idle(anim)
            .End();
    }
}