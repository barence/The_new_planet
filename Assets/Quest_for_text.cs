using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quest_for_text : MonoBehaviour
{
    public Text mytext = null;
    public int X = 0;
    public int C = 0;
    private bool quest_1_complete = false;
    void Start()
    {
        mytext.text = "follow the arrow to find me.";
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D say)
    {
        if (say.gameObject.CompareTag("Player") && (X < 7))
        {
            mytext.text = "now I will tell you the materials needed for a rocket that I will build so we can escape from planet earth and go to the new planet! now you will need to get 7 logs for the lanch pad. when you're done drop them right next to me or on top of me.";

        }
        if (say.gameObject.CompareTag("Player") && (X >= 7))
        {
            mytext.text = "Your second quest is find 8 glass bottles and 4 logs for the windows of the rocket";
        }
        if (say.gameObject.CompareTag("Player") && (C >= 8))
        {
            mytext.text = "Your third and final quest is find 3 rocks, 5 scraps, and 12 wires for the control of the rocket";
        }
    }
    void OnCollisionExit2D(Collision2D talk)
    {
        mytext.text = " ";


    }
    void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("log")) //&&
        {

            X = X + 1;
            item.gameObject.SetActive(false);
        }
        if (item.gameObject.CompareTag("bottle"))// && (X >= 7))
        {

            C = C + 1;
            item.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if ((X == 7) && (quest_1_complete == false))
        {
            GameObject.Find("pad").GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            mytext.text = "congrats you finshed the launch pad now come to me for your next quest.";
            quest_1_complete = true;
        }
        if ((X == 11) && (C == 8))
        {
        mytext.text = "congrats you finshed the windows now come to me for your next quest.";

        }
    }
}
