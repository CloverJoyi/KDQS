using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Rigidbody2D player;
    private Rigidbody2D boss;
    private float reboundDir;
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        boss = gameObject.transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        canAttack = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player" && canAttack)
        {
            player = collision.GetComponent<Rigidbody2D>();
            canAttack = false;
            Debug.Log("玩家受到伤害");
            collision.GetComponent<PlayerHealth>().TakeDamage(1);
            Repel();
        }
    }


    //玩家回弹
    private void Repel()
    {
        reboundDir = boss.transform.position.x - player.transform.position.x;
        if (reboundDir > 0)
        {
            reboundDir = -1;
        }
        else
        {
            reboundDir = 1;
        }
        player.velocity = new Vector2(reboundDir * 18, 8);
        Invoke("EmergencyStop", 0.1f);
    }

    private void EmergencyStop()
    {
        player.velocity = new Vector2(0, 0);
    }
}
