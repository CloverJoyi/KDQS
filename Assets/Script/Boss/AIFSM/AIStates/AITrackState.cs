using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrackState : AIBehaviourStateBase
{
    private bool canTrack = true;
    private float tracktimer = 0f;
    private float moveSpeedX = 5f;
    private float moveSpeedY;
    private float accelerationY = 10f;
    public AITrackState(MonoBehaviour mono, Rigidbody2D rb2D, Transform ai) : base(mono, rb2D, ai)
    {
    }

    public override void OnEnter()
    {
        m_trackRequest = false;
        m_fsm.PlayAnimation("Track");
    }

    public override void OnUpdate()
    {
        if (m_diedRequest)
        {
            m_fsm.TransitionState(AIStateType.Died);
        }

        tracktimer += Time.deltaTime;
        if (tracktimer > 0.2f && canTrack)
        {
            Debug.Log("Track");
            AIMove();
            canTrack = false;
        }
        if (m_rb.velocity.y == 0 && !canTrack)
        {
            m_fsm.TransitionState(AIStateType.Idle);
        }
    }

    public override void OnExit()
    {
        tracktimer = 0f;
        canTrack = true;
    }


    public void AIMove()
    {
        if (ExploreAreaUtil.WatchBox(m_rb))
        {
            Collider2D playerCollider = ExploreAreaUtil.WatchBox(m_rb);
            Vector2 playerPos = playerCollider.transform.position;
            Vector2 aiPos = m_ai.position;
            Vector2 relativeDir = (playerPos - aiPos).normalized;
            float distanceX = Mathf.Abs(playerPos.x - aiPos.x);
            float moveTime = distanceX / moveSpeedX;
            moveSpeedY = accelerationY * (moveTime / 2);


            m_rb.velocity = relativeDir * moveSpeedX + Vector2.up * moveSpeedY;
        }
        else
        {
            float dir = GetDir();
            if (dir < 0)
            {
                dir = 1;
            }
            else
            {
                dir = -1;

            }
            m_rb.velocity = new Vector2(dir * 5, 8);
        }
    }
}
