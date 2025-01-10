using UnityEngine;

public class Track : Behavior{
    private Rigidbody2D m_rb;
    private Animator m_anim;
    private Transform m_player;

    private bool canTrack = true;
    private float tracktimer = 0f;
    private float moveSpeedX = 5f;
    private float moveSpeedY;
    private float accelerationY = 10f;

    public Track(Rigidbody2D rb, Animator anim){
        m_rb = rb;
        m_anim = anim;
        m_player = GameObject.Find("Player").transform;
    }

    protected override void OnInitialize(){
        m_anim.Play("Track");
    }

    protected override EStatus OnUpdate(){
        tracktimer += Time.deltaTime;
        if (tracktimer > 0.2f && canTrack){
            //Debug.Log("Track");
            AIMove();
            canTrack = false;
        }

        if (tracktimer > 0.4f && Test0.bossOnGroung){
            //m_anim.Play("Idle");
            return EStatus.Success;
        }
        // if (m_rb.velocity == Vector2.zero){
        //     
        // }

        return EStatus.Running;
    }

    protected override void OnTerminate(){
        tracktimer = 0f;
        canTrack = true;
    }

    public void AIMove(){
        Vector2 playerPos = m_player.position;
        Vector2 aiPos = m_rb.position;
        Debug.Log(playerPos);
        Vector2 relativeDir = (playerPos - aiPos).normalized;
        float distanceX = Mathf.Abs(playerPos.x - aiPos.x);
        float moveTime = distanceX / moveSpeedX;
        moveSpeedY = accelerationY * (moveTime / 2);

        m_rb.velocity = relativeDir * moveSpeedX + Vector2.up * moveSpeedY;

        //m_rb.velocity = new Vector2(dir * 5, 8);
    }
}

public partial class BehaviorTreeBuilder{
    public BehaviorTreeBuilder Track(Rigidbody2D rb, Animator anim){
        var node = new Track(rb, anim);
        AddBehavior(node);
        return this;
    }
}