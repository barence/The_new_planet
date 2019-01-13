using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

    public AudioSource tickSource;

    public float speed;

    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        rb2D.AddForce(movement * speed);
    }

	// Update is called once per frame
	void Update () {

        tickSource = GetComponent<AudioSource>();

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("apple"))
        {
            tickSource.Play();
            other.gameObject.SetActive(false);
        }
    }
}
