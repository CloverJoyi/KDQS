using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyAttack : MonoBehaviour
{
    private static GameObject col;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            col = other.gameObject;
            Debug.Log("Hit Boss");
            gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }


    public static GameObject GetTarget()
    {
        return col;
    }


}
