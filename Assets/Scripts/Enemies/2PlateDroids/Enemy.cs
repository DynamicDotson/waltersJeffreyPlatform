using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Health = 3;

    public GameObject DeathEffect;

    public EnemyFallow FallowCode;

    public Collider2D MYCollider;

    public Slider HealthBar;

    public GameObject DeathDeletedObject;

    public Animator MyAnimator;

    public SpriteRenderer MySpriteRenderer;  
    public void TakeDamage(int damage)
    {

        Health -= damage;
        HealthBar.value = Health;
        if (Health <= 0)
        {

            Die();
        }
    }

  

    void Die()
    {
        MySpriteRenderer.enabled = false;
        MyAnimator.enabled = false;
        MYCollider.enabled = false;
        FallowCode.enabled = false;
        DeathDeletedObject.SetActive(true);
    }
}
