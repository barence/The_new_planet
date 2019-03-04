
using UnityEngine;

public class moveforward : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 4, Space.Self);
    }

    
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            transform.Translate(Vector3.right * -1f, Space.Self);
        }
    }
}