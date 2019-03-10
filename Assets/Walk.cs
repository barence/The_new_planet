using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walk : MonoBehaviour
{
   
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
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("apple"))
        {
            GameObject.Find("Canvas").GetComponent<Hunger>().DealHunger(-10);
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
}
