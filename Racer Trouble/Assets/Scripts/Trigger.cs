using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            StartCoroutine(Mover());
        }
        IEnumerator Mover()
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.transform.parent.position = new Vector3(0, 0, gameObject.transform.position.z + 200);
        }
    }
}
