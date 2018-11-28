using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPickup : MonoBehaviour {

    public int pickupAmount = 10;
    //public ParticleSystem energypickupParticle;

    private void OnTriggerEnter(Collider other)
    {
        //checks to see if the object colliding with them is the player
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        //checks to see if the player is active
        if (player != null)
        {
            //increases the players energy if the interact with the energy pickup
            player.playerEnergy += pickupAmount;
            // Instantiate(energypickupParticle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
