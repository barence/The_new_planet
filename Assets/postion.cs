using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class postion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 new_position;
        new_position = GameObject.Find("enemy").transform.position;
        gameObject.transform.position = new_position;
    }
}
