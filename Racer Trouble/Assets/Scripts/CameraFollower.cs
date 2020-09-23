using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float speed1;
    public float speeder;
    // Start is called before the first frame update
    void Start()
    {
        speeder = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (speeder > 0)
        {
            speeder -= Time.deltaTime;
        }
        if (speeder < 0)
        {
            speed1++;
            speeder = 4f;
        }
        transform.Translate(Vector3.forward * speed1 * Time.deltaTime);
    }  
}
