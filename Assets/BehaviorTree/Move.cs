using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Behavior{
    private Rigidbody2D m_rb;
    private Vector2 m_point1;
    private Vector2 m_point2;
    private int random;

    public Move(Rigidbody2D rb, Transform point1, Transform point2){
        m_rb = rb;
        m_point1 = point1.position;
        m_point2 = point2.position;
        random = Random.Range(0, 2);
    }

    protected override EStatus OnUpdate(){
        switch (random){
            case 0:
                m_rb.transform.position = Vector3.MoveTowards(m_rb.position, m_point2, 2 * Time.deltaTime);
                if (m_rb.position != m_point2)
                    return EStatus.Running;
                break;
            case 1:
                m_rb.transform.position = Vector3.MoveTowards(m_rb.position, m_point1, 2 * Time.deltaTime);
                if (m_rb.position != m_point1)
                    return EStatus.Running;
                break;
        }

        random = Random.Range(0, 2);
        return EStatus.Success;
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder Move(Rigidbody2D rb, Transform point1, Transform point2){
        var node = new Move(rb, point1, point2);
        AddBehavior(node);
        return this;
    }
}