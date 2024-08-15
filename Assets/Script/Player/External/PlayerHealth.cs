using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 5;
    private float energy = 0f;
    private float maxEnergy = 100f;
    private float InvincibleTime = 1f;
    private bool canHurted = true;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canHurted == false)
        {
            timer += Time.deltaTime;
            if (timer >= InvincibleTime)
            {
                canHurted = true;
                timer = 0f;
            }
        }

    }

    public void TakeDamage(int damage)
    {
        if (canHurted)
        {
            canHurted = false;
            health -= damage;
            if (health <= 0f)
            {
                health = 0f;
            }
            HealthBar.Instance.SetValue(health / 5f);
        }
    }

    public float GetHealth()
    {
        return health;
    }

    public void PlayerHealthReset()
    {
        health = 5;
    }

    public float GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(float soul)
    {
        energy += soul;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        if (energy <= 0f)
        {
            energy = 0f;
        }
        EnergyBar.Instance.SetValue(energy / maxEnergy);
    }
}
