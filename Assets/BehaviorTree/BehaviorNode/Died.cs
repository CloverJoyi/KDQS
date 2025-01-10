using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Died : Behavior{
    private Animator m_anim;
    private Rigidbody2D m_rb;
    private Vector2 m_pos;

    public Died(Animator anim, Rigidbody2D rb){
        m_anim = anim;
        m_rb = rb;
    }

    protected override void OnInitialize(){
        m_pos = m_rb.position;
        m_rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        m_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        m_anim.Play("Died");
    }

    protected override EStatus OnUpdate(){
        while (true){
            m_rb.position = m_pos;
            return EStatus.Running;
        }
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder Died(Animator anim, Rigidbody2D rb){
        var node = new Died(anim, rb);
        AddBehavior(node);
        return this;
    }
}