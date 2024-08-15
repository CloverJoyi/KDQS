using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth m_health;
    public float energyIncome = 10f;
    private bool canAttack = true;
    private float reboundDir;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
        m_health = player.GetComponent<PlayerHealth>();
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
        if (collision.tag == "Boss" && canAttack)
        {
            canAttack = false;
            collision.GetComponent<BossHealth>().TakeDamage(5);
            m_health.SetEnergy(energyIncome);
            Repel();
        }
    }


    //玩家回弹
    private void Repel()
    {
        if (player.transform.localScale.x > 0)
        {
            reboundDir = 1;
        }
        else
        {
            reboundDir = -1;
        }
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(-reboundDir * 18, 0);
        Invoke("EmergencyStop", 0.1f);
    }

    private void EmergencyStop()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
