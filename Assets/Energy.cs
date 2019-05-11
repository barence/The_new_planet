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
        DealEnergy(Time.deltaTime * -3);
        
            if (Input.GetKey(KeyCode.LeftShift))
        {
            DealEnergy(0.5F);

        }
        Energybar.value = CalculateEnergy(); 
            if (Input.GetKeyDown(KeyCode.Space))
            {
            DealEnergy(5);

            }
    }

   public void DealEnergy(float damageValue)
    {
        CurrentEnergy -= damageValue;
    }




    float CalculateEnergy()
    {
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, 0, 100);
        return CurrentEnergy / MaxEnergy;
    }
}