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
    

        Healthbar.value = CalculateHealth();
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DealDamage(10);
        }
        if (GameObject.Find("hunger Canvas").GetComponent<Hunger>().CurrentHunger == 0)
        {
            DealDamage(Time.deltaTime * 5f);
            Healthbar.value = CalculateHealth();
        }

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