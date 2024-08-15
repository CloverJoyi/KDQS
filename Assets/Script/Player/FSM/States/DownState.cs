using UnityEngine;

public class DownState : BehaviourStateBase
{
    private float timer = 0;
    private float m_forwardRock = 0.5f;
    private float energyCost = -30f;
    private float currentEnergy;
    private float currentGravityScale;
    private PlayerHealth m_health;



    public DownState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player, PlayerHealth health) : base(mono, rb2D, inputSpace, player)
    {
        m_health = health;
    }


    public override void OnEnter()
    {
        currentGravityScale = m_rb.gravityScale;
        m_skillDownRequest = false;
        currentEnergy = m_health.GetEnergy();
        if (currentEnergy < Mathf.Abs(energyCost))
        {
            m_fsm.TransitionState(StateType.Idle);
            Debug.Log("Not enough energy");
        }
        else
        {

            m_rb.velocity = Vector2.zero;
            m_rb.gravityScale = 0;
            m_fsm.PlayAnimation("Down");
            m_health.SetEnergy(energyCost);
        }
    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        timer += Time.deltaTime;
        if (timer > m_forwardRock)
        {
            m_rb.gravityScale = currentGravityScale;

            SkillDown();
        }
        if (Triggers.isGround)
        {
            m_fsm.TransitionState(StateType.Idle);
        }
    }

    public override void OnExit()
    {
        m_fsm.PlayAnimation("Land");
        timer = 0;
        m_rb.gravityScale = currentGravityScale;
    }
}