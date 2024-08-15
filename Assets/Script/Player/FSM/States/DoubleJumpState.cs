using Exaple;
using UnityEngine;

public class DoubleJumpState : BehaviourStateBase
{

    public DoubleJumpState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
    {

    }


    public override void OnEnter()
    {
        m_jumpRequest = false;
        jumpCount = 3;
        DoubleJump();
    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        m_fsm.PlayAnimation("DoubleJump");
        if (m_movementRequest)
        {
            m_movementRequest = false;
            m_inputDir.x = m_input.GetInputData<InputDataTest>().playerInput.x;
            Move(m_inputDir);
        }
        if (m_dashRequest && canDash)
        {
            canDash = false;
            m_fsm.TransitionState(StateType.Dash);
        }
        if (m_attackRequest)
        {
            m_fsm.TransitionState(StateType.Attack);
        }
        if (m_shootRequest)
        {
            m_fsm.TransitionState(StateType.Shoot);
        }
        if (m_skillDownRequest)
        {
            m_fsm.TransitionState(StateType.Down);

        }
        if (m_rb.velocity.y < 0f)
        {
            m_fsm.TransitionState(StateType.Fall);
        }

    }

    public override void OnExit()
    {

    }



}