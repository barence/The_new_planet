
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            DealHunger(10);
        }
        DealHunger(Time.deltaTime/0.5f);
        Hungerbar.value = CalculateHunger();
    }

    public void DealHunger(float damageValue)
    {
        CurrentHunger -= damageValue;
    }




    float CalculateHunger()
    {
        CurrentHunger = Mathf.Clamp(CurrentHunger, 0, 100);
        return CurrentHunger / MaxHunger;
    }
}