using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public float CurrentEnergy { get; set; }
    public float MaxEnergy { get; set; }
    public float Calculate { get; set; }

    public Slider Energybar;

    void Start()
    {
        MaxEnergy = 100f;
        CurrentEnergy = MaxEnergy;


        Energybar.value = CalculateEnergy();
    }

    void Update() {
        DealDamage(Time.deltaTime * -3);
        
            if (Input.GetKey(KeyCode.LeftShift))
        {
            DealDamage(0.5F);

        }
        Energybar.value = CalculateEnergy();
    }

    void DealDamage(float damageValue)
    {
        CurrentEnergy -= damageValue;
    }




    float CalculateEnergy()
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, 100);
        return CurrentEnergy / MaxEnergy;
    }
}