using System;
using UnityEngine;

public interface IPlayerBase
{
    public StateHandlerBase stateHandler { get; }
    public BehaviourBase behaviour { get; }
    public RequestHandlerBase requestHandler { get; }
    public RequestReceiverBase receiver { get; }
    public InvokerBase invoker { get; }
    public PlayerInputBase input { get; }


    public FSM fsm { get; }
    public BehaviourStateBase movement { get; }
    public BehaviourStateBase idle { get; }
    public BehaviourStateBase jump { get; }
    public BehaviourStateBase doubleJump { get; }
    public BehaviourStateBase fall { get; }
    public BehaviourStateBase dash { get; }
    public BehaviourStateBase attack { get; }
    public BehaviourStateBase shoot { get; }
    public BehaviourStateBase down { get; }
    public BehaviourStateBase died { get; }
    public BehaviourStateBase hurt { get; }
}

public abstract class PlayerBase : Agent, IPlayerBase
{
    public StateHandlerBase stateHandler { get; private set; }
    public BehaviourBase behaviour { get; private set; }
    public RequestHandlerBase requestHandler { get; private set; }
    public RequestReceiverBase receiver { get; private set; }
    public InvokerBase invoker { get; private set; }
    public PlayerInputBase input { get; private set; }


    public FSM fsm { get; private set; }
    public BehaviourStateBase movement { get; private set; }
    public BehaviourStateBase idle { get; private set; }
    public BehaviourStateBase jump { get; private set; }
    public BehaviourStateBase doubleJump { get; private set; }
    public BehaviourStateBase fall { get; private set; }
    public BehaviourStateBase dash { get; private set; }
    public BehaviourStateBase attack { get; private set; }
    public BehaviourStateBase shoot { get; private set; }
    public BehaviourStateBase down { get; private set; }
    public BehaviourStateBase died { get; private set; }
    public BehaviourStateBase hurt { get; private set; }


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

    #region StateMachineData
    protected abstract string fsmClass { get; }
    protected abstract object[] fsmArgs { get; }
    protected abstract string movementClass { get; }
    protected abstract object[] movementArgs { get; }
    protected abstract string idleClass { get; }
    protected abstract object[] idleArgs { get; }
    protected abstract string jumpClass { get; }
    protected abstract object[] jumpArgs { get; }
    protected abstract string doubleJumpClass { get; }
    protected abstract object[] doubleJumpArgs { get; }
    protected abstract string fallClass { get; }
    protected abstract object[] fallArgs { get; }
    protected abstract string dashClass { get; }
    protected abstract object[] dashArgs { get; }
    protected abstract string attackClass { get; }
    protected abstract object[] attackArgs { get; }
    protected abstract string shootClass { get; }
    protected abstract object[] shootArgs { get; }
    protected abstract string downClass { get; }
    protected abstract object[] downArgs { get; }
    protected abstract string diedClass { get; }
    protected abstract object[] diedArgs { get; }
    protected abstract string hurtClass { get; }
    protected abstract object[] hurtArgs { get; }

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
        input = ActivatorUtil.CreateInstance<PlayerInputBase>(ActivatorUtil.GetFrameWoekType(inputClass), inputArgs);


        jump = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(jumpClass), jumpArgs);
        doubleJump = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(doubleJumpClass), doubleJumpArgs);
        fall = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(fallClass), fallArgs);
        movement = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(movementClass), movementArgs);
        idle = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(idleClass), idleArgs);
        dash = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(dashClass), dashArgs);
        attack = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(attackClass), attackArgs);
        shoot = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(shootClass), shootArgs);
        died = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(diedClass), diedArgs);
        down = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(downClass), downArgs);
        hurt = ActivatorUtil.CreateInstance<BehaviourStateBase>(ActivatorUtil.GetFrameWoekType(hurtClass), hurtArgs);
        fsm = ActivatorUtil.CreateInstance<FSM>(ActivatorUtil.GetFrameWoekType(fsmClass), fsmArgs);




        Debug.Log("FramWorkInit Succeed");

    }
    private void EndOfInit()
    {
        movement.SetInput(input);
        jump.SetInput(input);
        doubleJump.SetInput(input);
        fall.SetInput(input);


        idle.SetFSM(fsm);
        movement.SetFSM(fsm);
        jump.SetFSM(fsm);
        doubleJump.SetFSM(fsm);
        fall.SetFSM(fsm);
        dash.SetFSM(fsm);
        attack.SetFSM(fsm);
        shoot.SetFSM(fsm);
        down.SetFSM(fsm);
        died.SetFSM(fsm);
        hurt.SetFSM(fsm);
    }
    protected void OnInit()
    {
        //data,framework,EndOfInit
        AgentDataInit();
        Triggers.Init();
        FrameWorkInit();
        EndOfInit();
        fsm.Init();

    }
    protected void OnUpdate()
    {
        stateHandler.Update();
        input.Update();
        invoker.Update();
        requestHandler.Update();
        fsm.Update();
        Triggers.Update();
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
