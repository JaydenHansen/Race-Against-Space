using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyReduce : MonoBehaviour {

    public PlayerController playerMove;
    public Slider energyBar;
    public Text deathText;
    public RawImage playerIcon;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (playerMove == null)
        {
            energyBar.value = 0;
        }
        else
        {
            energyBar.value = playerMove.energy;
        }
        if(energyBar.value <= 0)
        {
            deathText.text = "Connection Lost";
            Destroy(energyBar);
            Destroy(playerIcon);
        }
       
    }
}
