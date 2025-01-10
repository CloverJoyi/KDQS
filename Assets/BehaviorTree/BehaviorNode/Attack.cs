using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Behavior{
    private Rigidbody2D m_rb;
    private GameObject m_attackBox;
    private Animator m_anim;
    private float timer;
    private float forwardTime = 0.5f;
    private float durTime = 1f;
    private float backTime = 1f;

    public static int attackCount = 0;

    public Attack(Rigidbody2D rb, Animator anim){
        m_rb = rb;
        m_anim = anim;
        m_attackBox = m_rb.transform.GetChild(0).gameObject;
        AI_AttackInactive();
    }

    protected override void OnInitialize(){
        attackCount++;
        m_anim.Play("Attack");
    }

    protected override EStatus OnUpdate(){
        timer += Time.deltaTime;
        if (timer >= forwardTime){
            AI_AttackActive();
        }

        if (timer >= durTime){
            AI_AttackInactive();
        }

        if (timer >= backTime){
            return EStatus.Success;
        }

        return EStatus.Running;
    }

    protected override void OnTerminate(){
        timer = 0;
    }

    public void AI_AttackActive(){
        m_attackBox.SetActive(true);
    }

    public void AI_AttackInactive(){
        m_attackBox.SetActive(false);
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder Attack(Rigidbody2D rb, Animator anim){
        var node = new Attack(rb, anim);
        AddBehavior(node);
        return this;
    }
}