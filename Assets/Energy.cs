using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public float CurrentEnergy { get; set; }
    public float MaxEnergy { get; set; }

    public Slider Energybar;

    void Start()
    {
        MaxEnergy = 100f;
        CurrentEnergy = MaxEnergy;


        Energybar.value = CalculateEnergy();
    }

    void Update()

    {
       
        Energybar.value = CalculateEnergy();
    }

    void DealDamage(float damageValue)
    {
        CurrentEnergy -= damageValue;
    }




    float CalculateEnergy()
    {
        return CurrentEnergy / MaxEnergy;
    }
}