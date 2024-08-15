using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIBehaviourStateBase
{
    private float calmdownTime = 3f;
    private float timer = 0f;
    private int count = 0;
    public AIIdleState(MonoBehaviour mono, Rigidbody2D rb2D, Transform ai) : base(mono, rb2D, ai)
    {
    }

    public override void OnEnter()
    {

    }

    public override void OnUpdate()
    {
        m_fsm.PlayAnimation("Idle");

        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            Steering();
        }
        if (m_diedRequest)
        {
            m_fsm.TransitionState(AIStateType.Died);
        }
        if (timer >= calmdownTime)
        {
            if (m_trackRequest && count <= 3)
            {
                m_fsm.TransitionState(AIStateType.Track);
            }
            if (m_attackRequest && count <= 3)
            {
                count++;
                m_fsm.TransitionState(AIStateType.Attack);
            }
            if (count > 3)
            {
                count = 0;
                m_fsm.TransitionState(AIStateType.Skill);
            }

        }

    }

    public override void OnExit()
    {
        timer = 0f;
    }


}
