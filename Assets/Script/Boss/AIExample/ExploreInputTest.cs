using UnityEngine;
public class ExploreDataTest : ExploreData
{
    public bool desiredTrack;
    public bool desiredAttack;
    public bool desiredSkill;
    public bool desiredHurted;
    public bool desiredDied;

}


public class ExploreInputTest : ExploreInputBase
{
    public readonly ExploreDataTest exploreData;
    private Rigidbody2D m_rb;
    private BossHealth m_health;

    public ExploreInputTest(InvokerBase invoker, Rigidbody2D rb, BossHealth health) : base(invoker, rb, health)
    {
        exploreData = GetExploreData<ExploreDataTest>();
        m_rb = rb;
        m_health = health;
    }

    protected override void GetExplore()
    {
        exploreData.desiredTrack = ExploreAreaUtil.WatchBox(m_rb);
        exploreData.desiredAttack = ExploreAreaUtil.AttackBox(m_rb);
        exploreData.desiredDied = isDied();
    }

    protected override void CallCommand()
    {
        if (exploreData.desiredTrack == true)
        {
            Debug.Log("顺利发送AI跟随指令");
            m_invoker.Call((int)AICallID.Track);//此处应为attack的ID
            exploreData.desiredTrack = false;
        }
        if (exploreData.desiredAttack == true)
        {
            Debug.Log("顺利发送AI攻击指令");
            m_invoker.Call((int)AICallID.Attack);//此处应为attack的ID
            exploreData.desiredAttack = false;
        }
        if (exploreData.desiredTrack == true)
        {
            Debug.Log("顺利发送AI技能指令");
            m_invoker.Call((int)AICallID.Skill);//此处应为attack的ID
            exploreData.desiredSkill = false;
        }
        if (exploreData.desiredDied == true)
        {
            Debug.Log("顺利发送AI死亡指令");
            m_invoker.Call((int)AICallID.Died);//此处应为attack的ID
            exploreData.desiredDied = false;
        }

    }

    private bool isDied()
    {
        if (m_health.GetHealth() <= 0)
        {
            return true;
        }
        else return false;
    }

    protected override void EndOfUpdate()
    {
        base.EndOfUpdate();
    }

    protected override void FixedCallCommand()
    {
        base.FixedCallCommand();
    }


}
