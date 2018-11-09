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
        PlayerUI.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        //PlayerUI.SetActive(true);
        if (playerMove == null)
        {
            energyBar.value = 0;
        }
        else
        {
            energyBar.value = playerMove.playerEnergy;
        }
        if(energyBar.value <= 0)
        {
            deathText.text = "Connection Lost";
            Destroy(energyBar);
            Destroy(playerIcon);
        }
		if (energyBar.value > 100) 
		{
			energyBar.value = 100; 
		}
        
        if (!playerMove.gameObject.activeInHierarchy)
        {
            //PlayerUI.SetActive(false); 
            energyBar.value = 0;
            //PlayerUI.SetActive(false); 
            
        }
       
    }
}
