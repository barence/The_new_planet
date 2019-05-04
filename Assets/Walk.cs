using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Walk : MonoBehaviour
{

    private List<GameObject> deactivated_log_game_objects = new List<GameObject>();
    private List<GameObject> deactivated_scrap_game_objects = new List<GameObject>();
    private List<GameObject> deactivated_bottle_game_objects = new List<GameObject>();
    private List<GameObject> deactivated_rock_game_objects = new List<GameObject>();
    private int log_count;
    private int scrap_count;
    private int bottle_count;
    private int rock_count;
    private float corn_time;
    public AudioSource tickSource;
    public Text wire_supply_text;
    public Text scrap_supply_text;
    public Text bottle_supply_text;
    public Text rock_supply_text;
    public Text log_supply_text;
    private float speed;
    private const int v = 1;
    private int wire_count;
    private List<GameObject> deactivated_wire_game_objects = new List<GameObject>();
    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start()

    {
        rb2D = GetComponent<Rigidbody2D>();
        wire_count = 0;
        wire_supply_text.text = " " + wire_count.ToString();

        rb2D = GetComponent<Rigidbody2D>();
        log_count = 0;
        log_supply_text.text = " " + log_count.ToString();

        rb2D = GetComponent<Rigidbody2D>();
        scrap_count = 0;
        scrap_supply_text.text = " " + scrap_count.ToString();

        rb2D = GetComponent<Rigidbody2D>();
        rock_count = 0;
        rock_supply_text.text = " " + rock_count.ToString();

        rb2D = GetComponent<Rigidbody2D>();
        bottle_count = 0;
        bottle_supply_text.text = " " + bottle_count.ToString();
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
        speed = 10;
        float energy = GameObject.Find("Canvas").GetComponent<Energy>().CurrentEnergy;
        if (energy > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                speed = 20;
        }
        {
            if (Input.GetKey(KeyCode.Insert))
                speed = 500;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {


            if (deactivated_wire_game_objects.Count > 0)
            {

                wire_count = wire_count - v;
                int last_wire_index = deactivated_wire_game_objects.Count - v;
                deactivated_wire_game_objects[last_wire_index].transform.position = GameObject.Find("player").transform.position + Vector3.right * 2;
                deactivated_wire_game_objects[last_wire_index].SetActive(true);
                deactivated_wire_game_objects.RemoveAt(last_wire_index);
                wire_supply_text.text = " " + wire_count.ToString();

            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {


            if (deactivated_log_game_objects.Count > 0)
            {

                log_count = log_count - v;
                int last_log_index = deactivated_log_game_objects.Count - v;
                deactivated_log_game_objects[last_log_index].transform.position = GameObject.Find("player").transform.position + Vector3.right * 2;
                deactivated_log_game_objects[last_log_index].SetActive(true);
                deactivated_log_game_objects.RemoveAt(last_log_index);
                log_supply_text.text = " " + log_count.ToString();

            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (deactivated_scrap_game_objects.Count > 0)
            {

                scrap_count = scrap_count - v;
                int last_scrap_index = deactivated_scrap_game_objects.Count - v;
                deactivated_scrap_game_objects[last_scrap_index].transform.position = GameObject.Find("player").transform.position + Vector3.right * 2;
                deactivated_scrap_game_objects[last_scrap_index].SetActive(true);
                deactivated_scrap_game_objects.RemoveAt(last_scrap_index);
                scrap_supply_text.text = " " + scrap_count.ToString();
            }
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (deactivated_rock_game_objects.Count > 0)
            {

                rock_count = rock_count - v;
                int last_rock_index = deactivated_rock_game_objects.Count - v;
                deactivated_rock_game_objects[last_rock_index].transform.position = GameObject.Find("player").transform.position + Vector3.right * 2;
                deactivated_rock_game_objects[last_rock_index].SetActive(true);
                deactivated_rock_game_objects.RemoveAt(last_rock_index);
                rock_supply_text.text = " " + rock_count.ToString();

            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (deactivated_bottle_game_objects.Count > 0)
            {
                bottle_count = bottle_count - v;
                int last_bottle_index = deactivated_bottle_game_objects.Count - v;
                deactivated_bottle_game_objects[last_bottle_index].transform.position = GameObject.Find("player").transform.position + Vector3.right * 2;
                deactivated_bottle_game_objects[last_bottle_index].SetActive(true);
                deactivated_bottle_game_objects.RemoveAt(last_bottle_index);
                bottle_supply_text.text = " " + bottle_count.ToString();
            }
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
            deactivated_wire_game_objects.Add(other.gameObject);
            wire_count = wire_count + v;
            wire_supply_text.text = " " + wire_count.ToString();
        }
        if (other.gameObject.CompareTag("log"))
        {
            other.gameObject.SetActive(false);
            deactivated_log_game_objects.Add(other.gameObject);
            log_count = log_count + v;
            log_supply_text.text = " " + log_count.ToString();
        }

        if (other.gameObject.CompareTag("scrap"))
        {
            other.gameObject.SetActive(false);
            deactivated_scrap_game_objects.Add(other.gameObject);
            scrap_count = scrap_count + v;
            scrap_supply_text.text = " " + scrap_count.ToString();
        }

        if (other.gameObject.CompareTag("rock"))
        {
            other.gameObject.SetActive(false);
            deactivated_rock_game_objects.Add(other.gameObject);
            rock_count = rock_count + v;
            rock_supply_text.text = " " + rock_count.ToString();
        }

        if (other.gameObject.CompareTag("bottle"))
        {
            other.gameObject.SetActive(false);
            deactivated_bottle_game_objects.Add(other.gameObject);
            bottle_count = bottle_count + v;
            bottle_supply_text.text = " " + bottle_count.ToString();
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