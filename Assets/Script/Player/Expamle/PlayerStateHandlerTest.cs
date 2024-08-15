using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandlerTest : StateHandlerBase
{
    private PlayerStateTest m_stateTest;

    public PlayerStateHandlerTest(Animator anim) : base(anim)
    {
    }

    protected override void StateConfiguration()
    {
        m_stateTest = new PlayerStateTest();
        m_stateData.Add(m_stateTest);
    }

    protected override void StateConditionConfiguration()
    {

        m_stateCondition.Add(RequestID.Move, () =>
        {
            if ((m_stateTest.state &
                    (
                        PlayerStateTest.PlayerStateID.idle |
                        PlayerStateTest.PlayerStateID.move |
                        PlayerStateTest.PlayerStateID.jump |
                        PlayerStateTest.PlayerStateID.doubleJump |
                        PlayerStateTest.PlayerStateID.fall
                    )
                ) != 0
                )
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Jump, () =>
        {
            if ((m_stateTest.state & (PlayerStateTest.PlayerStateID.idle | PlayerStateTest.PlayerStateID.move | PlayerStateTest.PlayerStateID.jump | PlayerStateTest.PlayerStateID.fall)) != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Attack, () =>
        {
            if ((m_stateTest.state &
                    (
                        PlayerStateTest.PlayerStateID.idle |
                        PlayerStateTest.PlayerStateID.move |
                        PlayerStateTest.PlayerStateID.jump |
                        PlayerStateTest.PlayerStateID.doubleJump |
                        PlayerStateTest.PlayerStateID.fall
                    )
                ) != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Dash, () =>
        {
            if ((m_stateTest.state &
                    (
                        PlayerStateTest.PlayerStateID.idle |
                        PlayerStateTest.PlayerStateID.move |
                        PlayerStateTest.PlayerStateID.jump |
                        PlayerStateTest.PlayerStateID.doubleJump |
                        PlayerStateTest.PlayerStateID.fall
                    )
                ) != 0
                )
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Down, () =>
        {
            if (!Triggers.isGround)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Shoot, () =>
        {
            if ((m_stateTest.state &
                    (
                        PlayerStateTest.PlayerStateID.idle |
                        PlayerStateTest.PlayerStateID.move |
                        PlayerStateTest.PlayerStateID.jump |
                        PlayerStateTest.PlayerStateID.doubleJump |
                        PlayerStateTest.PlayerStateID.fall
                    )
                ) != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Hurted, () =>
        {
            if (m_stateTest.state != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(RequestID.Died, () =>
        {
            if ((m_stateTest.state & PlayerStateTest.PlayerStateID.hurted) != 0)
            {
                return true;
            }
            return false;
        });
    }

    protected override void OnInit()
    {
        m_stateTest.state = PlayerStateTest.PlayerStateID.idle;
    }

    protected override void OnFixedUpdate()
    {
        UpdatePlayerState();
    }

    private void UpdatePlayerState()
    {
        if (isInTransition) return;

        if (currentStateHash == Animator.StringToHash("Idle"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.idle;
        }
        else if (currentStateHash == Animator.StringToHash("Jump"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.jump;
        }
        else if (currentStateHash == Animator.StringToHash("Move"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.move;
        }

        else if (currentStateHash == Animator.StringToHash("Attack"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.attack;
        }
        else if (currentStateHash == Animator.StringToHash("Down"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.down;
        }
        else if (currentStateHash == Animator.StringToHash("Shoot"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.shoot;
        }
        else if (currentStateHash == Animator.StringToHash("DoubleJump"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.doubleJump;
        }
        else if (currentStateHash == Animator.StringToHash("Fall"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.fall;
        }
        else if (currentStateHash == Animator.StringToHash("Land"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.land;
        }
        else if (currentStateHash == Animator.StringToHash("hurted"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.hurted;
        }
        else if (currentStateHash == Animator.StringToHash("Died"))
        {
            m_stateTest.state = PlayerStateTest.PlayerStateID.died;
        }
    }

}
