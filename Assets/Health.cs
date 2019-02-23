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
        GameObject.Find("BOOM").GetComponent<Text>().canvasRenderer.SetAlpha(0);
    }

    void Update()
    {
        DealDamage(Time.deltaTime * -1);
        if (Input.GetKeyDown(KeyCode.Z))
        {
        DealDamage(10);
        }
        if (GameObject.Find("Canvas").GetComponent<Hunger>().CurrentHunger == 0)
        {
            DealDamage(Time.deltaTime * 10f);
            Healthbar.value = CalculateHealth();
        }

        Healthbar.value = CalculateHealth();
    }

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        if (CurrentHealth <= 0)
        {
            GameObject.Find("BOOM").GetComponent<Text>().canvasRenderer.SetAlpha(1);
        }
    }

    float CalculateHealth()
    {

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 100);
        return CurrentHealth / MaxHealth;
    }

}