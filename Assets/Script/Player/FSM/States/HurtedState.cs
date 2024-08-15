using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtedState : BehaviourStateBase
{
    private GameObject boss;
    private PlayerHealth m_health;
    private float reboundDir;
    private float timer = 0;
    private float currentHealth;

    public HurtedState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player, PlayerHealth health) : base(mono, rb2D, inputSpace, player)
    {
        m_health = health;

    }

    public override void OnEnter()
    {
        currentHealth = m_health.GetHealth();
        m_hurtRequest = false;
        boss = PlayerBodyAttack.GetTarget();
        m_fsm.PlayAnimation("Hurted");
        Debug.Log("Hurted");
        Repel();
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            m_rb.velocity = Vector2.zero;
            m_rb.gravityScale = 0;
        }
        if (timer > 0.3f)
        {
            if (currentHealth <= 0)
            {
                m_fsm.TransitionState(StateType.Died);
            }
            else
                m_fsm.TransitionState(StateType.Idle);
        }
    }

    public override void OnExit()
    {
        timer = 0;
        m_rb.gravityScale = 1;
    }

    private void Repel()
    {
        reboundDir = boss.transform.position.x - m_player.transform.position.x;
        if (reboundDir > 0)
        {
            reboundDir = -1;
        }
        else
        {
            reboundDir = 1;
        }
        m_rb.velocity = new Vector2(reboundDir * 8, 4);
    }
}
