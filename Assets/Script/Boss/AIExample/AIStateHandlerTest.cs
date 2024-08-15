using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateHandlerTest : StateHandlerBase
{
    private AIStateTest m_aiStateTest;

    public AIStateHandlerTest(Animator anim) : base(anim)
    {
    }

    protected override void StateConfiguration()
    {
        m_aiStateTest = new AIStateTest();
        m_aiStateData.Add(m_aiStateTest);
    }

    protected override void StateConditionConfiguration()
    {

        m_stateCondition.Add(AIRequestID.Track, () =>
        {
            if ((m_aiStateTest.state & (AIStateTest.AIStateID.idle)) != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(AIRequestID.Attack, () =>
        {
            if ((m_aiStateTest.state & (AIStateTest.AIStateID.idle)) != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(AIRequestID.Skill, () =>
        {
            if ((m_aiStateTest.state & (AIStateTest.AIStateID.idle)) != 0)
            {
                return true;
            }
            return false;
        });

        m_stateCondition.Add(AIRequestID.Died, () => { return true; });

    }

    protected override void OnInit()
    {
        m_aiStateTest.state = AIStateTest.AIStateID.idle;
    }

    protected override void OnFixedUpdate()
    {
        UpdateAIState();
    }

    private void UpdateAIState()
    {
        if (isInTransition) return;

        if (currentStateHash == Animator.StringToHash("Idle"))
        {
            m_aiStateTest.state = AIStateTest.AIStateID.idle;
        }
        else if (currentStateHash == Animator.StringToHash("Track"))
        {
            m_aiStateTest.state = AIStateTest.AIStateID.track;
        }
        else if (currentStateHash == Animator.StringToHash("Attack"))
        {
            m_aiStateTest.state = AIStateTest.AIStateID.attack;
        }
        else if (currentStateHash == Animator.StringToHash("Skill"))
        {
            m_aiStateTest.state = AIStateTest.AIStateID.skill;
        }
        else if (currentStateHash == Animator.StringToHash("Died"))
        {
            m_aiStateTest.state = AIStateTest.AIStateID.died;
        }
    }
}
