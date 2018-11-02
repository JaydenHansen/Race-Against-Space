using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour {

    //public PlayerController player1;
    //public PlayerController player2;
    //public PlayerController player3;
    //public PlayerController player420;
    public int survivors;
    //private List<PlayerController> players;
    public CharacterManager charMan;

    // Use this for initialization
    void Start ()
    {
        //// check how many players are in the game

        //for (int i = 0; i < players.Count; i++)
        //{
        //    if (players[i].energy > 0)
        //    {
                
        //    }
        //}


        
	}
	
	// Update is called once per frame  
	void Update ()
    {
        for (int i = 0; i < 4; i++)
        {
            if (CharacterManager.isPlaying[i])
            {
                if(charMan.characters[i].GetComponent<PlayerController>().playerEnergy > 0)
                {
                    survivors++;
                }
            }
        }
        //// check how many players are alive
        //if (energy > 0) //check if alive 
        //{
        //    PlayerControls.active;
        //   if(survivors <= 1)
        //   {
        //        for (int i = 1; i > survivors; i++)
        //            {

        //            }
        //   }
        //}

        if (survivors <= 1)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
