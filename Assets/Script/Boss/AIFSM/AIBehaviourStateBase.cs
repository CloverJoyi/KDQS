using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviourStateBase
{
    #region 标志

    public bool movementEnable { get; set; }//是否锁定移动

    #endregion

    #region 请求

    protected static bool m_trackRequest;
    protected static bool m_attackRequest;
    protected static bool m_skillRequest;
    protected static bool m_diedRequest;

    #endregion

    #region 可配置属性

    protected Transform m_ai;
    #endregion


    #region 基础


    private bool m_hasInit = false;//初始化
    //基于物理的角色控制
    protected Rigidbody2D m_rb;
    protected MonoBehaviour m_mono;//要将功能反映到unity中，必须要传入MonoBehaviour
    protected AIFSM m_fsm;
    protected Vector2 m_inputDir = Vector2.zero;//输入方向
    protected GameObject m_shootBullet;

    #endregion

    public AIBehaviourStateBase(MonoBehaviour mono, Rigidbody2D rb2D, Transform ai)
    {
        movementEnable = true;
        m_rb = rb2D;
        m_mono = mono;
        m_ai = ai;
        Init();
    }

    public virtual void SetFSM(AIFSM fsm)
    {
        m_fsm = fsm;
    }


    public static void ExecuteRequest(int request)
    {
        switch (request)
        {
            case AIRequestID.Track:
                m_trackRequest = true;
                break;
            case AIRequestID.Attack:
                m_attackRequest = true;
                break;
            case AIRequestID.Died:
                m_diedRequest = true;
                break;
        }
    }
    public static void CancelExecuteRequest(int request)
    {
        switch (request)
        {
            case AIRequestID.Track:
                m_trackRequest = false;
                break;
            case AIRequestID.Attack:
                m_attackRequest = false;
                break;
            case AIRequestID.Died:
                m_diedRequest = false;
                break;
        }
    }

    //模板方法
    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void OnUpdate()
    {
    }

    protected void Init()
    {
        if (m_hasInit) return;
        m_hasInit = true;
    }

    protected void Steering()
    {
        float dir = GetDir();
        if (dir < 0)
        {
            m_ai.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            m_ai.localScale = new Vector3(-1, 1, 1);

        }

    }

    protected float GetDir()
    {
        GameObject palyer = GameObject.FindGameObjectWithTag("Player");
        float dir = m_ai.position.x - palyer.transform.position.x;
        return dir;
    }

}
