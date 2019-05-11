using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour {
    public float CurrentbearHealth { get; set; }
    public float MaxbearHealth { get; set; }
    public Slider bearHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        MaxbearHealth = 100;
        CurrentbearHealth = MaxbearHealth;
        bearHealthbar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        DealDamage(Time.deltaTime * -1);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float dist = Vector3.Distance(GameObject.Find("player").transform.position, transform.position);
            if (dist < 5)
                DealDamage(2);
        }
    }
    public void DealDamage(float damageValue)
    {
        CurrentbearHealth -= damageValue;
        if (CurrentbearHealth <= 0)
        {
            GameObject o = GameObject.Find("enemy");
            if (o != null)
                o.SetActive(false);
        }
        bearHealthbar.value = CalculateHealth();
    }

    float CalculateHealth()
    {

        CurrentbearHealth = Mathf.Clamp(CurrentbearHealth, 0, 100);
        return CurrentbearHealth / MaxbearHealth;
    }
}
