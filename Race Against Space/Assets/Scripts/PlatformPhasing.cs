using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhasing : MonoBehaviour
{
    public Rigidbody playerRB;

    public Renderer rend;

    public Collider playerCollider;
    public Collider platformAbove;

    // Use this for initialization
    void Start()
    {
        playerRB = this.gameObject.GetComponent<Rigidbody>();
        playerCollider = this.gameObject.GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        float phaseShift = 0.1f;
        int overlaps = Physics.OverlapBox(transform.position + new Vector3(0, 0.83f, 0), new Vector3(0.17f, 0.83f, 0.17f), Quaternion.identity, LayerMask.GetMask("Platforms")).Length;
        
        // If player is traveling up (jumping) then disable
        if(playerRB.velocity.y > 0)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platforms"), true);
            phaseShift = Mathf.PingPong(Time.time, 0.6f);
            rend.material.SetFloat("_PhaseShift", phaseShift);
        }
        // If player is falling and not colliding with platform then enable
        else if (playerRB.velocity.y <= 0 && overlaps == 0) 
        {
            Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Platforms"), false);
        }
    }
}
