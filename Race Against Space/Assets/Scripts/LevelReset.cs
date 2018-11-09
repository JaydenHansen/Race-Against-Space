using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{ 
    public GameObject[] listOfPlayers;

    public float roundEndWaitTimer = 3f;
    private float timer;

    // Use this for initialization
    void Awake()
    {
        listOfPlayers = GameObject.FindGameObjectsWithTag("Player");
        timer = roundEndWaitTimer;
    }

    // Update is called once per frame  
    void Update()
    { 
        Debug.Log(ScoreManager.player1Score);

        listOfPlayers = GameObject.FindGameObjectsWithTag("Player");

        if(listOfPlayers.Length <= 1)
        {
            if(listOfPlayers[0].name.Equals("Mesh_Character_Bublek"))
            {
                if(ScoreManager.player1Score < 2)
                { 
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        ScoreManager.player1Score++;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        timer = roundEndWaitTimer;
                    }
                }
                else
                {
                    SceneManager.LoadScene(1);
                }
            }
            else if (listOfPlayers[0].name.Equals("Mesh_Character_Gurmpt"))
            {
              if (ScoreManager.player2Score < 2)
              {
                 timer -= Time.deltaTime;
                 if (timer <= 0)
                 {
                     ScoreManager.player2Score++;
                     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                     timer = roundEndWaitTimer;
                 }
              }
               else
               {
                   SceneManager.LoadScene(1);
               }
            }

           

            if (timer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                timer = roundEndWaitTimer;
            }
        }
    }
}
