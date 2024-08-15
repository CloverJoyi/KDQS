using System;
using System.Collections.Generic;
using UnityEngine;
public interface IStateHandler { }
public class PlayerStateBase
{

}
public class AIStateBase
{

}
public class StateHandlerBase : IStateHandler
{
    //public开头都写成属性形式放开头，首字母小写防止与方法名混淆
    public int currentStateHash { get; protected set; }
    public int currentTagHash { get; protected set; }
    public bool isInTransition { get; private set; }

    //其他私有字段命名m_开头
    protected List<PlayerStateBase> m_stateData;//PlayerStateBase列表
    protected List<AIStateBase> m_aiStateData;//AIStateBase列表
    protected Dictionary<int, Func<bool>> m_stateCondition;// 定义一个字典，通过传入ID返回当前请求是否可通过
    private Animator m_anim;//声明动画状态机
    private bool m_isInit = false;//初始化标志
    protected bool m_isGround;

    public StateHandlerBase(Animator anim)//构造函数，依赖于传入的动画状态机
    {
        m_anim = anim;
        m_stateData = new List<PlayerStateBase>();
        m_aiStateData = new List<AIStateBase>();
        m_stateCondition = new Dictionary<int, Func<bool>>();

        //读取配置
        StateConfiguration();
        StateConditionConfiguration();
        Init();

    }

    public T GetState<T>() where T : PlayerStateBase//获取状态
    {
        for (int i = 0; i < m_stateData.Count; i++)
        {
            if (m_stateData[i].GetType() == typeof(T))
            {
                return (T)m_stateData[i];
            }
        }
        return null;
    }

    public Func<bool> GetStateCondition(int stateID)
    {
        return m_stateCondition[stateID];//返回该状态跳转条件(委托)
    }


    //虚方法需要被重写
    protected virtual void StateConfiguration() { }//状态配置
    protected virtual void StateConditionConfiguration() { }//状态条件配置
    protected virtual void OnUpdate() { }//更新逻辑
    protected virtual void OnFixedUpdate() { }//固定更新逻辑
    protected virtual void OnInit() { }//初始化逻辑

    private void Init()
    {
        m_isInit = true;
        //执行初始化逻辑
        OnInit();
    }

    public void Update()
    {
        OnUpdate();
        m_isGround = Triggers.isGround;
    }

    public void FixedUpdate()
    {

        //处理动画
        UpdateAnimatorHash();
        OnFixedUpdate();
    }

    private void UpdateAnimatorHash()
    {
        if (CheckAnimIsTransition())
        {
            isInTransition = true;
            return;
        }
        isInTransition = false;
        currentStateHash = m_anim.GetCurrentAnimatorStateInfo(0).shortNameHash;//使用Animator.StringToHash生成的哈希值，传递的字符串不包含父层的名字，获取当前状态名字的hash值
        currentTagHash = m_anim.GetCurrentAnimatorStateInfo(0).tagHash;//该状态的标签hash值
    }
    private bool CheckAnimIsTransition()//是否在Transition
    {
        for (int i = 0; i < m_anim.layerCount; i++)
        {
            if (m_anim.IsInTransition(i))
            {
                return true;
            }
        }
        return false;
    }
}
