using UnityEngine;

public class AIDiedState : AIBehaviourStateBase
{
    public AIDiedState(MonoBehaviour mono, Rigidbody2D rb2D, Transform ai) : base(mono, rb2D, ai)
    {

    }

    public override void OnEnter()
    {
        m_fsm.PlayAnimation("Died");
        m_ai.GetComponent<Collider2D>().enabled = false;
        m_rb.gravityScale = 0;
        m_rb.velocity = Vector2.zero;
    }

    public override void OnUpdate()
    {
    }

    public override void OnExit()
    {

    }
}
