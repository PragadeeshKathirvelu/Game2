using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawner", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 35 * Time.deltaTime); // move the spawner
    }

    public void Spawner()
    {
        // selects within 0,1,2 (since 3 prefabs there, Spawner position, rotational degree of the spawner)
        Instantiate(obstacle[Random.Range(0, 2)], new Vector3(Random.Range(-7.3f,0f), transform.position.y, transform.position.z), Quaternion.identity); // identity=0deg rotation on x,y,z axis for the spawner.
    }
}
