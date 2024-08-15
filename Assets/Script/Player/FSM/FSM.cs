using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum StateType
{
    Idle,
    Move,
    Jump,
    DoubleJump,
    Dash,
    Fall,
    Attack,
    Shoot,
    Down,
    Died,
    Hurt,
}


public class FSM
{
    private Animator animator;
    private IPlayerBase m_player;
    protected BehaviourStateBase currentState;//当前状态

    protected Dictionary<StateType, BehaviourStateBase> states = new Dictionary<StateType, BehaviourStateBase>();//状态字典

    public FSM(Animator anim, IPlayerBase player)
    {
        animator = anim;
        m_player = player;
    }

    public void Init()
    {
        states.Add(StateType.Idle, m_player.idle);
        states.Add(StateType.Move, m_player.movement);
        states.Add(StateType.Jump, m_player.jump);
        states.Add(StateType.DoubleJump, m_player.doubleJump);
        states.Add(StateType.Fall, m_player.fall);
        states.Add(StateType.Dash, m_player.dash);
        states.Add(StateType.Attack, m_player.attack);
        states.Add(StateType.Shoot, m_player.shoot);
        states.Add(StateType.Down, m_player.down);
        states.Add(StateType.Hurt, m_player.hurt);
        states.Add(StateType.Died, m_player.died);

        TransitionState(StateType.Idle);
    }

    public void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(StateType Type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[Type];
        currentState.OnEnter();
    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }
}
