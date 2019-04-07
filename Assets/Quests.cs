using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quests : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = x + 1;
        GameObject.Find("startText").GetComponent<Text>().canvasRenderer.SetAlpha(1);
        GameObject.Find("Quest 1 Text").GetComponent<Text>().canvasRenderer.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
    
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
        if (item.gameObject.CompareTag("log"))
        {
            x = x + 1;
        }

}
    
    void OnCollisionExit2D(Collision2D talk)
    {
        GameObject.Find("Quest 1 Text").GetComponent<Text>().canvasRenderer.SetAlpha(0);


    }
    //if x = 1
    //{    
        
    }
//}
