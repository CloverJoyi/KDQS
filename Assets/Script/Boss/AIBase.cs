
using UnityEngine;

public interface IAIBase
{
    public StateHandlerBase stateHandler { get; }
    public BehaviourBase behaviour { get; }
    public RequestHandlerBase requestHandler { get; }
    public RequestReceiverBase receiver { get; }
    public InvokerBase invoker { get; }
    public ExploreInputBase input { get; }

    #region FSM

    public AIFSM aiFSM { get; }
    public AIBehaviourStateBase idle { get; }
    public AIBehaviourStateBase track { get; }
    public AIBehaviourStateBase attack { get; }
    public AIBehaviourStateBase skill { get; }
    public AIBehaviourStateBase died { get; }


    #endregion
}

public abstract class AIBase : Agent, IAIBase
{
    public StateHandlerBase stateHandler { get; private set; }

    public BehaviourBase behaviour { get; private set; }

    public RequestHandlerBase requestHandler { get; private set; }

    public RequestReceiverBase receiver { get; private set; }

    public InvokerBase invoker { get; private set; }

    public ExploreInputBase input { get; private set; }


    #region AIFSM
    public AIFSM aiFSM { get; private set; }

    public AIBehaviourStateBase idle { get; private set; }
    public AIBehaviourStateBase track { get; private set; }
    public AIBehaviourStateBase attack { get; private set; }
    public AIBehaviourStateBase skill { get; private set; }
    public AIBehaviourStateBase died { get; private set; }

    #endregion



    #region FramWorkClassData
    protected abstract string stateHandlerClass { get; }
    protected abstract object[] stateHandlerArgs { get; }
    protected abstract string behaviourClass { get; }
    protected abstract object[] behaviourArgs { get; }
    protected abstract string requestHandlerClass { get; }
    protected abstract object[] requestHandlerArgs { get; }
    protected abstract string receiverClass { get; }
    protected abstract object[] receiverArgs { get; }
    protected abstract string invokerClass { get; }
    protected abstract object[] invokerArgs { get; }
    protected abstract string inputClass { get; }
    protected abstract object[] inputArgs { get; }
    public Animator anim { get; protected set; }

    #endregion

    #region AIFSM
    protected abstract string aiFSMClass { get; }
    protected abstract object[] aiFSMArgs { get; }
    protected abstract string idleClass { get; }
    protected abstract object[] idleArgs { get; }
    protected abstract string trackClass { get; }
    protected abstract object[] trackArgs { get; }
    protected abstract string attackClass { get; }
    protected abstract object[] attackArgs { get; }
    protected abstract string skillClass { get; }
    protected abstract object[] skillArgs { get; }
    protected abstract string diedClass { get; }
    protected abstract object[] diedArgs { get; }

    #endregion

    private void AgentDataInit() { }
    private void FrameWorkInit()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Try FramWorkInit");
        //此处实例化所有的系统对象类(反射方法)
        stateHandler = ActivatorUtil.CreateInstance<StateHandlerBase>(ActivatorUtil.GetFrameWoekType(stateHandlerClass), stateHandlerArgs);
        behaviour = ActivatorUtil.CreateInstance<BehaviourBase>(ActivatorUtil.GetFrameWoekType(behaviourClass), behaviourArgs);
        requestHandler = ActivatorUtil.CreateInstance<RequestHandlerBase>(ActivatorUtil.GetFrameWoekType(requestHandlerClass), requestHandlerArgs);
        receiver = ActivatorUtil.CreateInstance<RequestReceiverBase>(ActivatorUtil.GetFrameWoekType(receiverClass), receiverArgs);
        invoker = ActivatorUtil.CreateInstance<InvokerBase>(ActivatorUtil.GetFrameWoekType(invokerClass), invokerArgs);
        input = ActivatorUtil.CreateInstance<ExploreInputBase>(ActivatorUtil.GetFrameWoekType(inputClass), inputArgs);

        track = ActivatorUtil.CreateInstance<AIBehaviourStateBase>(ActivatorUtil.GetFrameWoekType(trackClass), trackArgs);
        idle = ActivatorUtil.CreateInstance<AIBehaviourStateBase>(ActivatorUtil.GetFrameWoekType(idleClass), idleArgs);
        attack = ActivatorUtil.CreateInstance<AIBehaviourStateBase>(ActivatorUtil.GetFrameWoekType(attackClass), attackArgs);
        skill = ActivatorUtil.CreateInstance<AIBehaviourStateBase>(ActivatorUtil.GetFrameWoekType(skillClass), skillArgs);
        died = ActivatorUtil.CreateInstance<AIBehaviourStateBase>(ActivatorUtil.GetFrameWoekType(diedClass), diedArgs);
        aiFSM = ActivatorUtil.CreateInstance<AIFSM>(ActivatorUtil.GetFrameWoekType(aiFSMClass), aiFSMArgs);


        Debug.Log("FramWorkInit Succeed");

    }

    private void EndOfInit()
    {
        idle.SetFSM(aiFSM);
        track.SetFSM(aiFSM);
        attack.SetFSM(aiFSM);
        skill.SetFSM(aiFSM);
        died.SetFSM(aiFSM);


    }
    protected void OnInit()
    {
        //data,framework,EndOfInit
        AgentDataInit();
        FrameWorkInit();
        EndOfInit();
        aiFSM.Init();

    }
    protected void OnUpdate()
    {
        stateHandler.Update();
        input.Update();
        invoker.Update();
        requestHandler.Update();
        aiFSM.Update();
    }

    protected void OnFixedUpdate()
    {
        stateHandler.FixedUpdate();
        input.FixedUpdate();
        invoker.FixedUpdate();
        requestHandler.FixedUpdate();
    }

    protected void Awake()
    {
        OnInit();
    }

    private void Update()
    {
        OnUpdate();
    }
    private void FixedUpdate()
    {
        OnFixedUpdate();
    }
}
