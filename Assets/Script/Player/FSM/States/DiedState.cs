using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedState : BehaviourStateBase
{
    private float timer = 0;
    public DiedState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player) : base(mono, rb2D, inputSpace, player)
    {
    }

    public override void OnEnter()
    {
        m_fsm.PlayAnimation("Died");
        //m_player.GetComponent<Collider2D>().enabled = false;
        m_rb.gravityScale = 0;
        m_rb.velocity = Vector2.zero;
        Debug.Log("Died");
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            m_rb.gravityScale = 2;
        }
    }

    public override void OnExit()
    {

    }
}
