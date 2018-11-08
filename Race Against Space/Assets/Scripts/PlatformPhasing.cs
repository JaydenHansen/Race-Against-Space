using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhasing : MonoBehaviour
{

    public Collider playerCollider;
    public Collider platformAbove;

    // Use this for initialization
    void Start()
    {
        playerCollider = this.gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        platformAbove = other.gameObject.GetComponent<Collider>();

        Physics.IgnoreCollision(playerCollider, platformAbove, true);
    }

   private void OnTriggerExit(Collider other)
   {
       Physics.IgnoreCollision(playerCollider, platformAbove, false);
   
       platformAbove = null;
   }
}
