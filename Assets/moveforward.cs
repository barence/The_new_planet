
using UnityEngine;

public class moveforward : MonoBehaviour
{
 void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 4, Space.Self);
    }
}