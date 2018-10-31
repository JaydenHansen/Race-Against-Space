using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyReduce : MonoBehaviour {

    public PlayerController playerMove;
    public Slider energyBar;
    public Text deathText;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        energyBar.value = playerMove.energy;
        if(energyBar.value <= 0)
        {
            deathText.IsActive();
            deathText.text = "Connection Lost";
            Destroy(energyBar);
        }
        if(playerMove == null)
        {
            energyBar.value = 0; 
        }
    }
}
