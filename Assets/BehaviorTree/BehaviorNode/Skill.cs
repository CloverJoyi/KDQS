using UnityEngine;

public class Skill : Behavior{
    private Rigidbody2D m_rb;
    private Animator m_anim;
    private float rushSpeed = 10f;
    private float forwardTime = 1f;
    private float durTime = 2f;
    private float timer = 0;

    public Skill(Rigidbody2D rb, Animator anim){
        m_rb = rb;
        m_anim = anim;
    }

    protected override void OnInitialize(){
        m_anim.Play("SkillFore");
    }

    protected override EStatus OnUpdate(){
        timer += Time.deltaTime;
        if (timer > forwardTime){
            AI_Skill();
            m_anim.Play("SkillDuring");
        }

        if (timer > durTime){
            return EStatus.Success;
        }

        return EStatus.Running;
    }

    protected override void OnTerminate(){
        timer = 0;
    }

    public void AI_Skill(){
        m_rb.velocity = new Vector2(m_rb.transform.localScale.x * rushSpeed, m_rb.velocity.y);
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder Skill(Animator anim, Rigidbody2D rb){
        var node = new Skill(rb, anim);
        AddBehavior(node);
        return this;
    }
}