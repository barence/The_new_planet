using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    public float rotSpeed = 150f;

    Transform larry;

    void Update()
    {
        if (larry == null)
        {

           // GameObject.Find("player").transform.position + Vector3.right * 2;

            GameObject go = GameObject.Find("larry");

            if (go != null)
            {
                larry = go.transform;
            }
        }

        if (larry == null)
            return;

        Vector3 dir = larry.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 360;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
