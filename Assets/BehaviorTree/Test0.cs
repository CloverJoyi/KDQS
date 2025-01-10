using System;
using UnityEngine;

public class Test0 : MonoBehaviour{
    public Animator anim;
    public static Rigidbody2D rb;
    public static bool haveHatred = false; //仇恨判断
    public static bool bossOnGroung;
    public static bool attack => ExploreAreaUtil.AttackBox(rb) == null ? false : true;
    public static bool watch => ExploreAreaUtil.WatchBox(rb) == null ? false : true;

    private BehaviorTreeBuilder builder;
    private GameObject boss_GroundCheck;


    private void Awake(){
        builder = new BehaviorTreeBuilder();
        rb = this.GetComponent<Rigidbody2D>();
        boss_GroundCheck = GameObject.Find("BossGroundCheck");
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
        bossOnGroung = IsBossGround();
    }


    // private void OnDrawGizmos(){
    //     ExploreAreaUtil.DrawWatchBox(rb);
    //     ExploreAreaUtil.DrawAttackBox(rb);
    // }

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
            .CDNode(5)
            .AttackTrigger(rb)
            .ChangeDirection(rb)
            .Attack(rb, anim)
            .Back()
            .Sequence()
            .CDNode(5)
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

    private bool IsBossGround(){
        return Physics2D.OverlapCircle(boss_GroundCheck.transform.position, 0.2f, Triggers.Ground);
    }
}