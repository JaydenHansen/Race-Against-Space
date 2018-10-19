using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterPlatforms : MonoBehaviour {

    public float timeBeforeShatter = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, timeBeforeShatter);
        }
    }
}
