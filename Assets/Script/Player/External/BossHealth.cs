using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //Debug.Log("Boss Health: " + health);
        if (health <= 0)
        {
            Debug.Log("Boss Dead");
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void BossHealthReset()
    {
        health = 100;
    }
}
