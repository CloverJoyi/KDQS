using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum AIStateType
{
    Idle,
    Track,
    Attack,
    Skill,
    Died,
}


public class AIFSM
{
    private Animator animator;
    private IAIBase m_ai;
    protected AIBehaviourStateBase currentState;//当前状态

    protected Dictionary<AIStateType, AIBehaviourStateBase> states = new Dictionary<AIStateType, AIBehaviourStateBase>();//状态字典

    public AIFSM(Animator anim, IAIBase ai)
    {
        animator = anim;
        m_ai = ai;
    }

    public void Init()
    {
        states.Add(AIStateType.Idle, m_ai.idle);
        states.Add(AIStateType.Track, m_ai.track);
        states.Add(AIStateType.Attack, m_ai.attack);
        states.Add(AIStateType.Skill, m_ai.skill);
        states.Add(AIStateType.Died, m_ai.died);

        TransitionState(AIStateType.Idle);
    }

    public void Update()
    {
        currentState.OnUpdate();
    }

    public void TransitionState(AIStateType Type)
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