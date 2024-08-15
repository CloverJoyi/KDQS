using UnityEngine;

public class ShootState : BehaviourStateBase
{
    private float m_shootTime = 0.8f;
    private float energyCost = -30f;
    private float currentEnergy;
    private float m_createBulletTime = 0.3f;
    private float timer = 0;
    private float currentGravityScale;
    private bool canShoot;
    private PlayerHealth m_health;


    public ShootState(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player, PlayerHealth health) : base(mono, rb2D, inputSpace, player)
    {
        m_health = health;
    }


    public override void OnEnter()
    {
        currentGravityScale = m_rb.gravityScale;
        m_shootRequest = false;
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
            canShoot = true;
            m_fsm.PlayAnimation("Shoot");
        }
    }

    public override void OnUpdate()
    {
        if (m_hurtRequest)
        {
            m_fsm.TransitionState(StateType.Hurt);
        }
        timer += Time.deltaTime;
        if (timer > m_createBulletTime && canShoot)
        {
            canShoot = false;
            m_health.SetEnergy(energyCost);
            Shoot();
        }
        if (timer > m_shootTime)
        {
            m_fsm.TransitionState(StateType.Idle);
        }
    }

    public override void OnExit()
    {
        m_rb.gravityScale = currentGravityScale;
        timer = 0;
    }
}
