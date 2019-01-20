
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hunger : MonoBehaviour
{
    public float CurrentHunger { get; set; }
    public float MaxHunger { get; set; }

    public Slider Hungerbar;

    void Start()
    {
        MaxHunger = 100f;
        CurrentHunger = MaxHunger;
        // Use this for initialization

        Hungerbar.value = CalculateHunger();
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.X))
            DealDamage(10);
        Hungerbar.value = CalculateHunger();
    }

    void DealDamage(float damageValue)
    {
        CurrentHunger -= damageValue;
    }




    float CalculateHunger()
    {
        return CurrentHunger / MaxHunger;
    }
}