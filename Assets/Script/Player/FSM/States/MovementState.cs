using Exaple;
using UnityEngine;

public class MovementState : BehaviourStateBase
{

    public MovementState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
    {

    }


    public override void OnEnter()
    {
        m_inputDir.x = m_input.GetInputData<InputDataTest>().playerInput.x;
    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        m_fsm.PlayAnimation("Move");
        if (m_movementRequest)
        {
            m_movementRequest = false;
            Move(m_inputDir);
        }
        else
        {
            m_inputDir = Vector2.zero;
            m_fsm.TransitionState(StateType.Idle);
        }
        if (m_jumpRequest && jumpCount < 2)
        {
            m_fsm.TransitionState(StateType.Jump);
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
        if (m_rb.velocity.y < -0.2f)
        {
            m_fsm.TransitionState(StateType.Fall);
        }
    }

    public override void OnExit()
    {

    }















}
