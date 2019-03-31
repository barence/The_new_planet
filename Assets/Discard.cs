using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : MonoBehaviour
{

    void Start()
    {

    }

    // does not get called when gameObject inactive
    void Update()
    {
        if  /*(gameObject.CompareTag("wire") && */ (gameObject.activeInHierarchy == false)
        {
            
                print("yodel");
                //transform.Translate(Vector3.right * Time.deltaTime * 4, Space.Self);
         
        }
    }
}