using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject[] listOfPlayers;
    public GameObject roundWinPlayer = null;
    public GameObject lastPlayerAlive;

	public GameObject player1WinScreen; 

    public int endSceneIndex = 1;

    public float timer = 1.0f;
    private float countdown;

    public float slowTime = 0.05f;
    public bool hasSlowed = false;

    public BlackholeManager blackhole;

    // Use this for initialization
    void Awake()
    {
        blackhole = GameObject.FindGameObjectWithTag("Blackhole").GetComponentInChildren<BlackholeManager>();

        listOfPlayers = GameObject.FindGameObjectsWithTag("Player");
        countdown = timer;
    }

    // Update is called once per frame  
    void Update()
    {
        listOfPlayers = GameObject.FindGameObjectsWithTag("Player");

        if (listOfPlayers.Length == 1)
        {
            roundWinPlayer = listOfPlayers[0];
            AddRoundTally();

            blackhole.gameObject.SetActive(false);
            listOfPlayers[0].GetComponent<PlayerController>().enabled = false;
        }
    }

    void AddRoundTally()
    {
        if(hasSlowed == false)
        {
            Time.timeScale -= 0.005f;
        }
        if (Time.timeScale <= slowTime)
        {
            hasSlowed = true;
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        { 
            if (roundWinPlayer.name.Equals("Mesh_Character_Full_01"))
            {
                if (ScoreManager.player1Score < 2)
                {
                    ScoreManager.player1Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
					ScoreManager.player1Score++;
                    //SceneManager.LoadScene(endSceneIndex);
                    //Time.timeScale = 1;
                    //ScoreReset();
					//player1WinScreen.SetActive(true);
                }
            }
            else if (roundWinPlayer.name.Equals("Mesh_Character_Full_01 (1)"))
            {
                if (ScoreManager.player2Score < 2)
                {
                    ScoreManager.player2Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    ScoreManager.player2Score++;
                    //SceneManager.LoadScene(endSceneIndex);
                    //Time.timeScale = 1;
                    //ScoreReset();

                }
            }
            else if (roundWinPlayer.name.Equals("Mesh_Character_Full_01 (2)"))
            {
                if (ScoreManager.player3Score < 2)
                {
                    ScoreManager.player3Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    ScoreManager.player3Score++;
                    //SceneManager.LoadScene(endSceneIndex);
                    //Time.timeScale = 1;
                    //ScoreReset();
                }
            }
            else if (roundWinPlayer.name.Equals("Mesh_Character_Full_01 (3)"))
            {
                if (ScoreManager.player4Score < 2)
                {
                    ScoreManager.player4Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    ScoreManager.player4Score++;
                    //SceneManager.LoadScene(endSceneIndex);
                    //Time.timeScale = 1;
                    //ScoreReset();
                }
            }
        }
    }

    void ScoreReset()
    {
        ScoreManager.player1Score = 0;
        ScoreManager.player2Score = 0;
        ScoreManager.player3Score = 0;
        ScoreManager.player4Score = 0;
    }
}
