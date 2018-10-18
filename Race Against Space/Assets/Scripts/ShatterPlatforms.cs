using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterPlatforms : MonoBehaviour {

    public int timeBeforeShatter = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 1 + timeBeforeShatter);
        }
    }
}
