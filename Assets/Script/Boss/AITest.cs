using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : AIBase
{
    protected override string stateHandlerClass => "AIStateHandlerTest";

    protected override object[] stateHandlerArgs => new object[] { anim };

    protected override string behaviourClass => "AIBehaviourTest";

    protected override object[] behaviourArgs => new object[] { this };

    protected override string requestHandlerClass => "AIRequestHandlerTest";

    protected override object[] requestHandlerArgs => new object[] { behaviour };

    protected override string receiverClass => "AIReceiverTest";

    protected override object[] receiverArgs => new object[] { requestHandler, behaviour, this };

    protected override string invokerClass => "AIInvokerTest";

    protected override object[] invokerArgs => new object[] { receiver };

    protected override string inputClass => "ExploreInputTest";

    protected override object[] inputArgs => new object[] { invoker, GetEnitityComponment<Rigidbody2D>(), GetEnitityComponment<BossHealth>() };

    #region AIFSM

    protected override string aiFSMClass => "AIFSM";

    protected override object[] aiFSMArgs => new object[] { anim, this };

    protected override string idleClass => "AIIdleState";

    protected override object[] idleArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity };

    protected override string trackClass => "AITrackState";

    protected override object[] trackArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity };

    protected override string attackClass => "AIAttackState";

    protected override object[] attackArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity };

    protected override string skillClass => "AISkillState";

    protected override object[] skillArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity };

    protected override string diedClass => "AIDiedState";

    protected override object[] diedArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity };
    #endregion
    private void OnDrawGizmos()
    {
        ExploreAreaUtil.DrawWatchBox(GetEnitityComponment<Rigidbody2D>());
        ExploreAreaUtil.DrawAttackBox(GetEnitityComponment<Rigidbody2D>());
    }


}
