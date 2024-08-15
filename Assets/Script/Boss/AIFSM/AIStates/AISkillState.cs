using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISkillState : AIBehaviourStateBase
{
    private float forwardTime = 1f;
    private float durTime = 2f;
    private float timer = 0;
    private float rushSpeed = 8f;

    public AISkillState(MonoBehaviour mono, Rigidbody2D rb2D, Transform ai) : base(mono, rb2D, ai)
    {
    }

    public override void OnEnter()
    {
        Steering();
        m_fsm.PlayAnimation("SkillFore");
    }

    public override void OnUpdate()
    {
        if (m_diedRequest)
        {
            m_fsm.TransitionState(AIStateType.Died);
        }
        timer += Time.deltaTime;
        if (timer > forwardTime)
        {
            AI_Skill();
            m_fsm.PlayAnimation("SkillDuring");
        }
        if (timer > durTime)
        {
            m_fsm.TransitionState(AIStateType.Idle);
        }
    }

    public override void OnExit()
    {
        timer = 0;
        m_rb.velocity = Vector2.zero;
    }

    public void AI_Skill()
    {
        m_rb.velocity = new Vector2(m_rb.transform.localScale.x * rushSpeed, m_rb.velocity.y);
    }
}
