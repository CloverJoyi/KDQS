using UnityEngine;

public class IdleState : BehaviourStateBase
{


    public IdleState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
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
        m_fsm.PlayAnimation("Idle");
        if (m_movementRequest)
        {
            m_fsm.TransitionState(StateType.Move);
        }
        if (m_jumpRequest)
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
