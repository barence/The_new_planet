using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quests : MonoBehaviour
{
    public int X = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("finish pad text").GetComponent<Text>().canvasRenderer.SetAlpha(0);
        GameObject.Find("startText").GetComponent<Text>().canvasRenderer.SetAlpha(1);
        GameObject.Find("Quest 1 Text").GetComponent<Text>().canvasRenderer.SetAlpha(0);
        GameObject.Find("pad").GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 0);
 
    }
    // Update is called once per frame
    void Update()
    {
        
        if (X == 7)
        {
            GameObject.Find("pad").GetComponent<MeshRenderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            GameObject.Find("finish pad text").GetComponent<Text>().canvasRenderer.SetAlpha(1);
        }
    }

    void OnCollisionEnter2D(Collision2D talk)
    {
        if (talk.gameObject.CompareTag("Player"))
        {
            GameObject.Find("startText").GetComponent<Text>().canvasRenderer.SetAlpha(0);
            GameObject.Find("Quest 1 Text").GetComponent<Text>().canvasRenderer.SetAlpha(1);
        }
    }

     void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("log") && (X < 7))
        {
           
            X = X + 1;
            item.gameObject.SetActive(false);
        }

}
    
    void OnCollisionExit2D(Collision2D talk)
    {
        GameObject.Find("Quest 1 Text").GetComponent<Text>().canvasRenderer.SetAlpha(0);


    }
     
}
