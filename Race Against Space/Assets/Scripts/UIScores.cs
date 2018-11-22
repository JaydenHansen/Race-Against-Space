using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class UIScores : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject player1Point1;
    public GameObject player1Point2;
    public GameObject player1Point3;
    public GameObject player1WinScreen;

    public GameObject player2Point1;
    public GameObject player2Point2;
    public GameObject player2Point3;
    public GameObject player2WinScreen;

    public GameObject player3Point1;
    public GameObject player3Point2;
    public GameObject player3Point3;
    public GameObject player3WinScreen;

    public GameObject player4Point1;
    public GameObject player4Point2;
    public GameObject player4Point3;
    public GameObject player4WinScreen;

    public XboxController controller; 

    private bool gameOver = false; 
    
    private void Update()
    {
        //checks if player is active
        if(player1 != null)
        {
            //checks the player score
            checkPlayer1Score();
        }
        //checks if player is active
        if (player2 != null)
        {
            //checks the player score
            checkPlayer2Score();
        }
        //checks if player is active
        if (player3 != null)
        {
            //checks the player score
            checkPlayer3Score();
        }
        //checks if player is active
        if (player4 != null)
        {
            //checks the player score
            checkPlayer4Score();
        }
        //checks to see if the round is currently over 
        checkGameOver();
    }

    private void checkGameOver()
    {
        //if someone has won runs this code
        if (gameOver)
        {
            //sets the time scale to 0 so the game pauses
            Time.timeScale = 0;
            //when the controller
			if (XCI.GetButton(XboxButton.Start, controller)) 
			{
                //sets the timescale to 1 so it resumes the game speed
				Time.timeScale = 1; 
                //reloads the main menu
				SceneManager.LoadScene (0);
			}
        }
    }
    //checks the score of player 1
    private void checkPlayer1Score()
    {
        //if the players score is 0
        if (ScoreManager.player1Score == 0)
        {
            //sets all points to 0
            player1Point1.SetActive(false);
            player1Point2.SetActive(false);
            player1Point3.SetActive(false);
            player1WinScreen.SetActive(false);
        }
        //if the players score is 1
        else if (ScoreManager.player1Score == 1)
        {
            //sets the first point to active
            player1Point1.SetActive(true);
            player1Point2.SetActive(false);
            player1Point3.SetActive(false);
            player1WinScreen.SetActive(false);
        }
        //if the players score is 2
        else if (ScoreManager.player1Score == 2)
        {
            //sets two point to active
            player1Point1.SetActive(true);
            player1Point2.SetActive(true);
            player1Point3.SetActive(false);
            player1WinScreen.SetActive(false);
        }
        //if the players score is 3
        else if (ScoreManager.player1Score == 3)
        {
            //sets all their points to active and shows the win screen
            player1Point1.SetActive(true);
            player1Point2.SetActive(true);
            player1Point3.SetActive(true);
            player1WinScreen.SetActive(true);
            //disables the controller
            player1.GetComponent<PlayerController>().enabled = false;
            //activates the game over
            gameOver = true;
        }
    }
    //checks the score of player 2
    private void checkPlayer2Score()
    {
        //if the players score is 0
        if (ScoreManager.player2Score == 0)
        {
            //sets all points to 0
            player2Point1.SetActive(false);
            player2Point2.SetActive(false);
            player2Point3.SetActive(false);
            player2WinScreen.SetActive(false);
        }
        //if the players score is 1
        else if (ScoreManager.player2Score == 1)
        {
            //sets the first point to active
            player2Point1.SetActive(true);
            player2Point2.SetActive(false);
            player2Point3.SetActive(false);
            player2WinScreen.SetActive(false);
        }
        //if the players score is 2
        else if (ScoreManager.player2Score == 2)
        {
            //sets two point to active
            player2Point1.SetActive(true);
            player2Point2.SetActive(true);
            player2Point3.SetActive(false);
            player2WinScreen.SetActive(false);
        }
        //if the players score is 3
        else if (ScoreManager.player2Score == 3)
        {
            //sets all their points to active and shows the win screen
            player2Point1.SetActive(true);
            player2Point2.SetActive(true);
            player2Point3.SetActive(true);
            player2WinScreen.SetActive(true);
            //disables the controller
            player2.GetComponent<PlayerController>().enabled = false;
            //activates the game over
            gameOver = true;
        }
    }
    //checks the score of player 3
    private void checkPlayer3Score()
    {
        //if the players score is 0
        if (ScoreManager.player3Score == 0)
        {
            //sets all points to 0
            player3Point1.SetActive(false);
            player3Point2.SetActive(false);
            player3Point3.SetActive(false);
            player3WinScreen.SetActive(false);
        }
        //if the players score is 1
        else if (ScoreManager.player3Score == 1)
        {
            //sets the first point to active
            player3Point1.SetActive(true);
            player3Point2.SetActive(false);
            player3Point3.SetActive(false);
            player3WinScreen.SetActive(false);
        }
        //if the players score is 2
        else if (ScoreManager.player3Score == 2)
        {
            //sets two point to active
            player3Point1.SetActive(true);
            player3Point2.SetActive(true);
            player3Point3.SetActive(false);
            player3WinScreen.SetActive(false);
        }
        //if the players score is 3
        else if (ScoreManager.player3Score == 3)
        {
            //sets all their points to active and shows the win screen
            player3Point1.SetActive(true);
            player3Point2.SetActive(true);
            player3Point3.SetActive(true);
            player3WinScreen.SetActive(true);
            //disables the controller
            player3.GetComponent<PlayerController>().enabled = false;
            //activates the game over
            gameOver = true;
        }
    }
    //checks the score of player 4
    private void checkPlayer4Score()
    {
        //if the players score is 0
        if (ScoreManager.player4Score == 0)
        {
            //sets all points to 0
            player4Point1.SetActive(false);
            player4Point2.SetActive(false);
            player4Point3.SetActive(false);
            player4WinScreen.SetActive(false);
        }
        //if the players score is 1
        else if (ScoreManager.player4Score == 1)
        {
            //sets the first point to active
            player4Point1.SetActive(true);
            player4Point2.SetActive(false);
            player4Point3.SetActive(false);
            player4WinScreen.SetActive(false);
        }
        //if the players score is 2
        else if (ScoreManager.player4Score == 2)
        {
            //sets two point to active
            player4Point1.SetActive(true);
            player4Point2.SetActive(true);
            player4Point3.SetActive(false);
            player4WinScreen.SetActive(false);
        }
        //if the players score is 3
        else if (ScoreManager.player4Score == 3)
        {
            //sets all their points to active and shows the win screen
            player4Point1.SetActive(true);
            player4Point2.SetActive(true);
            player4Point3.SetActive(true);
            player4WinScreen.SetActive(true);
            //disables the controller
            player4.GetComponent<PlayerController>().enabled = false;
            //activates the game over
            gameOver = true;
        }
    }
}