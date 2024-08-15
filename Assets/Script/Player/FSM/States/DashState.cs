using UnityEngine;

public class DashState : BehaviourStateBase
{
    private float timer = 0;
    private float dashTime = 0.3f;


    public DashState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
    {

    }


    public override void OnEnter()
    {
        m_dashRequest = false;

    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        timer += Time.deltaTime;
        if (timer > dashTime)
        {
            m_rb.velocity = Vector2.zero;
            m_fsm.TransitionState(StateType.Idle);
        }
        else
        {
            Dash();
            m_fsm.PlayAnimation("Dash");
        }

    }

    public override void OnExit()
    {
        timer = 0;
    }
}
