using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour
{
    public GameObject[] listOfPlayers;
   // public GameObject roundWinPlayer = null;

    public int endSceneIndex = 1;

    public float timer = 1.0f;
    private float countdown;

    public float slowTime = 0.05f;
    public bool hasSlowed = false;

    // Use this for initialization
    void Awake()
    {
        listOfPlayers = GameObject.FindGameObjectsWithTag("Player");
        countdown = timer;
    }

    // Update is called once per frame  
    void Update()
    {
        listOfPlayers = GameObject.FindGameObjectsWithTag("Player");

        if (listOfPlayers.Length <= 1)
        {
            AddRoundTally();
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
            if (listOfPlayers[0].name.Equals("Mesh_Character_Full_01"))
            {
                if (ScoreManager.player1Score < 2)
                {
                    ScoreManager.player1Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    SceneManager.LoadScene(endSceneIndex);
                    Time.timeScale = 1;
                    ScoreReset();
                }
            }
            else if (listOfPlayers[0].name.Equals("Mesh_Character_Full_01 (1)"))
            {
                if (ScoreManager.player2Score < 2)
                {
                    ScoreManager.player2Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    SceneManager.LoadScene(endSceneIndex);
                    Time.timeScale = 1;
                    ScoreReset();
                }
            }
            else if (listOfPlayers[0].name.Equals("Mesh_Character_Full_01 (2)"))
            {
                if (ScoreManager.player3Score < 2)
                {
                    ScoreManager.player3Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    SceneManager.LoadScene(endSceneIndex);
                    Time.timeScale = 1;
                    ScoreReset();
                }
            }
            else if (listOfPlayers[0].name.Equals("Mesh_Character_Full_01 (3)"))
            {
                if (ScoreManager.player4Score < 2)
                {
                    ScoreManager.player4Score++;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    Time.timeScale = 1;
                }
                else
                {
                    SceneManager.LoadScene(endSceneIndex);
                    Time.timeScale = 1;
                    ScoreReset();
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
