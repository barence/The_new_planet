using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Walk : MonoBehaviour
{
    private float corn_time;
    public AudioSource tickSource;
    public Text wire_supply_text;
    private float speed;
    private const int v = 1;
    private int wire_count;

    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        wire_count = 0;
        wire_supply_text.text = " " + wire_count.ToString();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        rb2D.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        tickSource = GetComponent<AudioSource>();
        speed = 35;
        float energy = GameObject.Find("Canvas").GetComponent<Energy>().CurrentEnergy;
        if (energy > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                speed = 70;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            wire_count = wire_count - v;
            wire_supply_text.text = " " + wire_count.ToString();
        }
        {
          if (corn_time > 0)
            {
                corn_time -= Time.deltaTime * 200f;
                GameObject.Find("Canvas").GetComponent<Hunger>().DealHunger(-0.025f);
            }

        }

    }
 

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("apple"))
        {
            GameObject.Find("Canvas").GetComponent<Hunger>().DealHunger(-10);
            tickSource.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("corn"))
        {
            corn_time = 1500;
                tickSource.Play();
                other.gameObject.SetActive(false);
            
        }
        if (other.gameObject.CompareTag("pricky pear"))
            {
                GameObject.Find("Canvas").GetComponent<Hunger>().DealHunger(-15);
            GameObject.Find("Canvas").GetComponent<Health>().DealDamage(5);
                tickSource.Play();
                other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("potato"))
        {
            GameObject.Find("Canvas").GetComponent<Hunger>().DealHunger(-7.5f);
            GameObject.Find("Canvas").GetComponent<Energy>().DealEnergy(-12.5f);
            tickSource.Play();
            other.gameObject.SetActive(false);
        }
            if (other.gameObject.CompareTag("wire"))
        {
            other.gameObject.SetActive(false);
            wire_count = wire_count + v;
            wire_supply_text.text = " " + wire_count.ToString();
        }


    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("enemy"))
        {
            GameObject.Find("Canvas").GetComponent<Health>().DealDamage(5f);
        }
    }

    //wire_supply_text = Mathf.Clamp(wire_supply_text, 0, 100);
       //return wire_supply_text / wire_count;
    
}

