using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GundraAttack : MonoBehaviour
{
    public int Health = 5;

    public GameObject DeathEffect;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
