using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyReduce : MonoBehaviour {

    public PlayerController playerMove;
    public GameObject PlayerUI;
    public Slider energyBar;
    public Text deathText;
    public RawImage playerIcon;
    // Use this for initialization
    void Start () {
        PlayerUI.SetActive(true);//sets the player UI to active
	}
	
	// Update is called once per frame
	void Update () {
        //PlayerUI.SetActive(true);
        //if player is null sets their energy to 0
        if (playerMove == null)
        {
            energyBar.value = 0;
        }
        else
        {
            //if the player is active set the energy value to be the players energy
            energyBar.value = playerMove.playerEnergy;
        }
        //if the energy is less than 0 
        if(energyBar.value <= 0)
        {
            //display connection lost and destroy their icon and remove their energy bar
            deathText.text = "Connection Lost";
            Destroy(energyBar);
            Destroy(playerIcon);
        }
        
        //if the player is inactive in the hieracy set the energy to 0
        if (!playerMove.gameObject.activeInHierarchy)
        {
            energyBar.value = 0;
        }
       
    }
}
