using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackoutTestScript : MonoBehaviour {
    private bool isBlackout = false;
    private float timer = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 5.0f && !isBlackout)
        {
            isBlackout = true;
            timer = 0.0f;
        }
        if (timer > 5.0f && isBlackout)
        {
            isBlackout = false;
            timer = 0.0f;
        }
        if (isBlackout)
        {
            this.GetComponent<Light>().enabled = false;
        }
        if (!isBlackout)
        {
            this.GetComponent<Light>().enabled = true;
        }
    }
}
