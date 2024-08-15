using UnityEngine;

public class AttackState : BehaviourStateBase
{
    private float attackTimer = 0.3f;
    private float timer = 0;


    public AttackState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
    {

    }


    public override void OnEnter()
    {
        m_attackRequest = false;
        Attack();
        m_fsm.PlayAnimation("Attack");
    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        timer += Time.deltaTime;
        if (timer > attackTimer)
        {
            m_fsm.TransitionState(StateType.Idle);
        }
    }

    public override void OnExit()
    {
        timer = 0;
        Triggers.AttackDisable();
    }
}