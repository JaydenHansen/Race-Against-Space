using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyUI : MonoBehaviour {

    // Use this for initialization
    public PlayerController playerMove;

    public Text energy;
    void Start(){ 
    }
	void FixedUpdate () {
        energy.text = playerMove.energy.ToString();
	}
}
