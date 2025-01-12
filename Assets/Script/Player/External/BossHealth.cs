using System;
using UnityEngine;

public class BossHealth : MonoBehaviour{
    public static int health = 80;

    public static event Action BossHurt;

    public void TakeDamage(int damage){
        health -= damage;
        //Debug.Log("Boss Health: " + health);
        BossHurt?.Invoke();
        if (health <= 0){
            Debug.Log("Boss Dead");
        }
    }

    public int GetHealth(){
        return health;
    }

    public void BossHealthReset(){
        health = 100;
    }
}