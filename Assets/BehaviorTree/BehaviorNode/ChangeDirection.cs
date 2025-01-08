
using UnityEngine;

public class ChangeDirection : Behavior
{
    private Rigidbody2D m_rb;
    
    public ChangeDirection(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    protected override void OnInitialize(){
        Steering();
    }

    protected override EStatus OnUpdate(){
        return EStatus.Success;
    }
    
    private void Steering()
    {
        float dir = GetDir();
        if (dir < 0)
        {
            m_rb.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            m_rb.transform.localScale = new Vector3(-1, 1, 1);

        }

    }

    private float GetDir()
    {
        GameObject palyer = GameObject.FindGameObjectWithTag("Player");
        float dir = m_rb.transform.position.x - palyer.transform.position.x;
        return dir;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder ChangeDirection(Rigidbody2D rb){
        var node = new ChangeDirection(rb);
        AddBehavior(node);
        return this;
    }
}

