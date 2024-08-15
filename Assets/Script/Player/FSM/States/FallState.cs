using Exaple;
using UnityEngine;

public class FallState : BehaviourStateBase
{


    public FallState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
    {

    }


    public override void OnEnter()
    {
    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        m_fsm.PlayAnimation("Fall");
        if (m_movementRequest)
        {
            m_movementRequest = false;
            m_inputDir.x = m_input.GetInputData<InputDataTest>().playerInput.x;
            Move(m_inputDir);
        }
        if (m_attackRequest)
        {
            m_fsm.TransitionState(StateType.Attack);
        }
        if (Triggers.isGround)
        {
            m_fsm.TransitionState(StateType.Idle);
        }
        if (m_dashRequest && canDash)
        {
            canDash = false;
            m_fsm.TransitionState(StateType.Dash);
        }
        if (m_shootRequest)
        {
            m_fsm.TransitionState(StateType.Shoot);
        }
        if (m_skillDownRequest)
        {
            m_fsm.TransitionState(StateType.Down);

        }
        if (m_jumpRequest == true && jumpCount < 2)
        {
            jumpCount++;
            m_fsm.TransitionState(StateType.DoubleJump);
        }
    }

    public override void OnExit()
    {
        if (Triggers.isGround)
        {
            m_fsm.PlayAnimation("Land");
        }
    }
}
