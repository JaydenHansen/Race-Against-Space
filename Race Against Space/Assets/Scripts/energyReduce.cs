using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyReduce : MonoBehaviour {

    public PlayerController playerMove;
    public Slider energyBar; 
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(-(0.15f), 0, 0) * Time.deltaTime);
        energyBar.value = playerMove.energy;
    }
}
