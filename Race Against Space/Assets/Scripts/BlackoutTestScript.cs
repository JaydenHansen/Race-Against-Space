using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutTestScript : MonoBehaviour {
    public Light playerGlow;
    private bool isBlackout = false;
    private float timer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //gets the timer ready
        timer += Time.deltaTime;
        //activates blackout after 5 seconds
        if(timer > 5.0f && !isBlackout)
        {
            isBlackout = true;//blackout activates
            timer = 0.0f;//timer is set back to 0    
        }

        //turns blackout off after 5 seconds of blackout
        if (timer > 5.0f && isBlackout)
        {
            isBlackout = false;//blackout deactivates 
            timer = 0.0f;//timer set back to 0
        }
        if (isBlackout)
        {
            //if the blackout is active it will turn off the level light and increase the intensity of the light the player gives off
            this.GetComponent<Light>().enabled = false;
            playerGlow.intensity = 20; 
            
            
        }
        if (!isBlackout)
        {
            //if blackout is inactive the level light will go on and the player's light intensity will be reduced
            this.GetComponent<Light>().enabled = true;
            playerGlow.intensity = 5;
        }
    }
}
