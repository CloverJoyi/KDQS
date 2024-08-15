using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackState : AIBehaviourStateBase
{
    private GameObject m_attackBox;
    private float forwardTime = 0.5f;
    private float durTime = 1f;
    private float backTime = 1f;
    private float timer = 0;
    public AIAttackState(MonoBehaviour mono, Rigidbody2D rb2D, Transform ai) : base(mono, rb2D, ai)
    {
        m_attackBox = m_ai.Find("AI_AttackBox").gameObject;
        m_attackBox.SetActive(false);
    }

    public override void OnEnter()
    {
        m_attackRequest = false;
        Debug.Log("Attack State");
        m_fsm.PlayAnimation("Attack");
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= forwardTime)
        {
            AI_AttackActive();
        }
        if (timer >= durTime)
        {
            AI_AttackInactive();
        }
        if (timer >= backTime)
        {
            m_fsm.TransitionState(AIStateType.Idle);
        }
    }

    public override void OnExit()
    {
        timer = 0;
        m_attackBox.SetActive(false);
    }

    public void AI_AttackActive()
    {
        m_attackBox.SetActive(true);
    }

    public void AI_AttackInactive()
    {
        m_attackBox.SetActive(false);
    }


}
