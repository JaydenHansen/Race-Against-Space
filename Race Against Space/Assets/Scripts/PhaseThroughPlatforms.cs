using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseThroughPlatforms : MonoBehaviour {

    public Collider thisPlatform;
    public Collider player;

    private void Start()
    {
        thisPlatform = this.gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<Collider>();

        Physics.IgnoreCollision(thisPlatform, player, true);
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(thisPlatform, player, false);
    }
}
