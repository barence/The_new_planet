using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    public float rotSpeed = 150f;

    Transform astro_dude;

    void Update()
    {
        if (astro_dude == null)
        {

           

            GameObject go = GameObject.Find("astro_dude");

            if (go != null)
            {
                astro_dude = go.transform;
            }
        }

        if (astro_dude == null)
            return;

        Vector3 dir = astro_dude.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 360;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
