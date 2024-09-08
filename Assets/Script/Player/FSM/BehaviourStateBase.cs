using System;
using UnityEngine;

public class BehaviourStateBase
{
    #region 标志

    public bool movementEnable { get; set; }//是否锁定移动
    private Vector2 m_faceDir = Vector2.zero;

    #endregion

    #region 请求

    protected static bool m_movementRequest;
    protected static bool m_jumpRequest;
    protected static bool m_dashRequest;
    protected static bool m_attackRequest;
    protected static bool m_skillDownRequest;
    protected static bool m_shootRequest;
    protected static bool m_hurtRequest;
    protected static bool m_diedRequest;

    #endregion

    #region 可配置属性
    protected float m_dashSpeed = 20f;//冲刺速度
    protected float m_v = 8f;//速度
    protected float m_jumpSpeed = 8f;
    public static int jumpCount;
    public static bool canDash;


    [SerializeField, Range(0, 90)] protected float m_slopeLimit = 25f;//坡度限制
    protected Transform m_playerInputSpace;//玩家输入空间(通常为摄像机)
    protected Transform m_player;
    #endregion


    #region 基础

    protected PlayerInputBase m_input;
    private bool m_hasInit = false;//初始化
    //基于物理的角色控制
    protected Rigidbody2D m_rb;
    protected MonoBehaviour m_mono;//要将功能反映到unity中，必须要传入MonoBehaviour
    protected FSM m_fsm;
    protected Vector2 m_inputDir = Vector2.zero;//输入方向
    protected GameObject m_shootBullet;

    #endregion

    public BehaviourStateBase(MonoBehaviour mono, Rigidbody2D rb2D, Transform inputSpace, Transform player)
    {
        movementEnable = true;
        m_rb = rb2D;
        m_mono = mono;
        m_player = player;
        m_playerInputSpace = inputSpace;
        Init();
    }

    public virtual void SetInput(PlayerInputBase input)
    {
        m_input = input;
    }

    public virtual void SetFSM(FSM fsm)
    {
        m_fsm = fsm;
    }


    public static void ExecuteRequest(int request)
    {
        switch (request)
        {
            case RequestID.Move:
                m_movementRequest = true;
                break;
            case RequestID.Jump:
                m_jumpRequest = true;
                break;
            case RequestID.Dash:
                m_dashRequest = true;
                break;
            case RequestID.Attack:
                m_attackRequest = true;
                break;
            case RequestID.Down:
                m_skillDownRequest = true;
                break;
            case RequestID.Shoot:
                m_shootRequest = true;
                break;
            case RequestID.Hurted:
                m_hurtRequest = true;
                break;
            case RequestID.Died:
                m_diedRequest = true;
                break;

        }
    }
    public static void CancelExecuteRequest(int request)
    {
        switch (request)
        {
            case RequestID.Move:
                m_movementRequest = false;
                break;
            case RequestID.Jump:
                m_jumpRequest = false;
                break;
            case RequestID.Dash:
                m_dashRequest = false;
                break;
            case RequestID.Attack:
                m_attackRequest = false;
                break;
            case RequestID.Down:
                m_skillDownRequest = false;
                break;
            case RequestID.Shoot:
                m_shootRequest = false;
                break;
            case RequestID.Hurted:
                m_hurtRequest = false;
                break;
            case RequestID.Died:
                m_diedRequest = false;
                break;
        }
    }

    //模板方法
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate() { }

    protected void Init()
    {
        if (m_hasInit) return;
        m_hasInit = true;
        jumpCount = 0;
        m_shootBullet = m_player.GetComponent<Agent>().bullet;
    }



    #region 动作实现



    //移动
    protected void Move(Vector2 inputDir)
    {
        //Debug.Log("执行了移动");
        m_rb.position = new Vector2(m_rb.position.x + inputDir.x * m_v * Time.deltaTime, m_rb.position.y);
        m_rb.transform.localScale = new Vector3(inputDir.x > 0 ? 1 : -1, 1, 1);//转向
    }



    //冲刺
    protected void Dash()
    {
        float dir = m_rb.transform.localScale.x;
        if (dir > 0)
        {
            m_faceDir = Vector2.right;
        }
        else
        {
            m_faceDir = Vector2.left;
        }
        m_rb.velocity = m_faceDir * m_dashSpeed;
        //Debug.Log("执行了冲刺");
        m_faceDir = Vector2.zero;
    }



    //跳跃
    protected void Jump()
    {
        Vector2 jumpDir = Vector2.up;
        m_rb.velocity += jumpDir * m_jumpSpeed;
        //Debug.Log("执行了跳跃");
        //m_anim.Play("Jump");
    }




    //二段跳
    protected void DoubleJump()
    {
        Vector2 jumpDir = Vector2.up;
        m_rb.velocity += jumpDir * m_jumpSpeed;
        //Debug.Log("执行了二段跳跃");
    }



    //攻击
    protected void Attack()
    {
        //Debug.Log("Attack");
        Triggers.AttackEnable();
    }



    //发射
    protected void Shoot()
    {
        //Debug.Log("Shoot");

        GameObject shootBullet = Agent.CreateShootBullet(m_shootBullet, m_rb.position);
        Rigidbody2D s_rb2D = shootBullet.GetComponent<Rigidbody2D>();
        float dir = m_rb.transform.localScale.x;
        if (dir > 0)
        {
            m_faceDir = Vector2.right;
        }
        else
        {
            m_faceDir = Vector2.left;
        }
        s_rb2D.AddForce(m_faceDir * 1000);

        m_faceDir = Vector2.zero;
    }



    //下砸
    protected void SkillDown()
    {
        //Debug.Log("SkillDown");
        m_rb.AddForce(-Vector2.up * 10);
    }


    #endregion
}
