using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : PlayerBase
{
    protected override string stateHandlerClass => "PlayerStateHandlerTest";

    protected override object[] stateHandlerArgs => new object[] { anim };

    protected override string behaviourClass => "BehaviourTest";

    protected override object[] behaviourArgs => new object[] { this };

    protected override string requestHandlerClass => "RequestHandlerTest";

    protected override object[] requestHandlerArgs => new object[] { behaviour };

    protected override string receiverClass => "ReceiverRequestTest";

    protected override object[] receiverArgs => new object[] { requestHandler, behaviour, this };
    protected override string invokerClass => "Exaple.InvokerTest";

    protected override object[] invokerArgs => new object[] { receiver };

    protected override string inputClass => "Exaple.AixsInputTest";

    protected override object[] inputArgs => new object[] { invoker, GetEnitityComponment<PlayerHealth>() };

    #region State

    protected override string fsmClass => "FSM";

    protected override object[] fsmArgs => new object[] { anim, this };

    protected override string movementClass => "MovementState";

    protected override object[] movementArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string idleClass => "IdleState";

    protected override object[] idleArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string jumpClass => "JumpState";

    protected override object[] jumpArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string doubleJumpClass => "DoubleJumpState";

    protected override object[] doubleJumpArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string fallClass => "FallState";

    protected override object[] fallArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string dashClass => "DashState";

    protected override object[] dashArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string attackClass => "AttackState";

    protected override object[] attackArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string shootClass => "ShootState";

    protected override object[] shootArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity, GetEnitityComponment<PlayerHealth>() };

    protected override string downClass => "DownState";

    protected override object[] downArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity, GetEnitityComponment<PlayerHealth>() };

    protected override string diedClass => "DiedState";

    protected override object[] diedArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity };

    protected override string hurtClass => "HurtedState";

    protected override object[] hurtArgs => new object[] { this, GetEnitityComponment<Rigidbody2D>(), entity, entity, GetEnitityComponment<PlayerHealth>() };

    #endregion



    public Vector3 rebornPos { get; private set; }//存档点

    public void UpdateRebornInPos(Vector3 pos)//更新存档点
    {
        rebornPos = pos;
    }

    private void Reborn()//复活
    {
        //Instantiate(this, rebornPos, Quaternion.identity);
    }

    private void OnDestroy()
    {
        Reborn();
    }

    void AttackOver()
    {
        Debug.Log("AttackOver");
        Triggers.AttackDisable();
    }

}
