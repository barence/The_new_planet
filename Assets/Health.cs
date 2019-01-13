using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider Healthbar;

    void Start()
    {
        MaxHealth = 100f;
        CurrentHealth = MaxHealth;
        // Use this for initialization

        Healthbar.value = CalculateHealth();
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.X))
            DealDamage(10);
        Healthbar.value = CalculateHealth();
    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
    }

    


    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }
}