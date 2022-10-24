using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
        bar.maxValue = Health.totalHealth;
        SetSize();
    }

    public void Damage(float damage)
    {
        if((Health.totalHealth -= damage) >= 0f)
        {
            Health.totalHealth -= damage;
        }
       else
        {
            Health.totalHealth = 0f;
        }
        SetSize();

    }


    public void SetSize()
    {
        bar.value = Health.totalHealth;
        Debug.Log(Health.totalHealth);
    }
}
