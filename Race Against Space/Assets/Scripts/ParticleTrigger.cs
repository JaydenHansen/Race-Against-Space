using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour {

    public ParticleSystem fallDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag.Equals("Player"))
        {
            Instantiate(fallDeath, other.transform.position, Quaternion.identity);
        }
    }
}
