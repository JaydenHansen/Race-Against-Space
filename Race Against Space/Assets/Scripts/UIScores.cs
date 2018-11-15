using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScores : MonoBehaviour
{
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
    
    private void Update()
    {
        checkPlayer1Score();
        checkPlayer2Score();
        checkPlayer3Score();
        checkPlayer4Score();
    }
    private void checkPlayer1Score()
    {
        if (ScoreManager.player1Score == 0)
        {
            player1Point1.SetActive(false);
            player1Point2.SetActive(false);
            player1Point3.SetActive(false);
            player1WinScreen.SetActive(false);
        }
        else if (ScoreManager.player1Score == 1)
        {
            player1Point1.SetActive(true);
            player1Point2.SetActive(false);
            player1Point3.SetActive(false);
            player1WinScreen.SetActive(false);
        }
        else if (ScoreManager.player1Score == 2)
        {
            player1Point1.SetActive(true);
            player1Point2.SetActive(true);
            player1Point3.SetActive(false);
            player1WinScreen.SetActive(false);
        }
        else if (ScoreManager.player1Score == 3)
        {
            player1Point1.SetActive(true);
            player1Point2.SetActive(true);
            player1Point3.SetActive(true);
            player1WinScreen.SetActive(true);
        }
    }
    private void checkPlayer2Score()
    {
        if (ScoreManager.player2Score == 0)
        {
            player2Point1.SetActive(false);
            player2Point2.SetActive(false);
            player2Point3.SetActive(false);
            player2WinScreen.SetActive(false);
        }
        else if (ScoreManager.player2Score == 1)
        {
            player2Point1.SetActive(true);
            player2Point2.SetActive(false);
            player2Point3.SetActive(false);
            player2WinScreen.SetActive(false);
        }
        else if (ScoreManager.player2Score == 2)
        {
            player2Point1.SetActive(true);
            player2Point2.SetActive(true);
            player2Point3.SetActive(false);
            player2WinScreen.SetActive(false);
        }
        else if (ScoreManager.player2Score == 3)
        {
            player2Point1.SetActive(true);
            player2Point2.SetActive(true);
            player2Point3.SetActive(true);
            player2WinScreen.SetActive(true);
        }
    }
    private void checkPlayer3Score()
    {
        if (ScoreManager.player3Score == 0)
        {
            player3Point1.SetActive(false);
            player3Point2.SetActive(false);
            player3Point3.SetActive(false);
            player3WinScreen.SetActive(false);
        }
        else if (ScoreManager.player3Score == 1)
        {
            player3Point1.SetActive(true);
            player3Point2.SetActive(false);
            player3Point3.SetActive(false);
            player3WinScreen.SetActive(false);
        }
        else if (ScoreManager.player3Score == 2)
        {
            player3Point1.SetActive(true);
            player3Point2.SetActive(true);
            player3Point3.SetActive(false);
            player3WinScreen.SetActive(false);
        }
        else if (ScoreManager.player3Score == 3)
        {
            player3Point1.SetActive(true);
            player3Point2.SetActive(true);
            player3Point3.SetActive(true);
            player3WinScreen.SetActive(true);
        }
    }
    private void checkPlayer4Score()
    {
        if (ScoreManager.player4Score == 0)
        {
            player4Point1.SetActive(false);
            player4Point2.SetActive(false);
            player4Point3.SetActive(false);
            player4WinScreen.SetActive(false);
        }
        else if (ScoreManager.player4Score == 1)
        {
            player4Point1.SetActive(true);
            player4Point2.SetActive(false);
            player4Point3.SetActive(false);
            player4WinScreen.SetActive(false);
        }
        else if (ScoreManager.player4Score == 2)
        {
            player4Point1.SetActive(true);
            player4Point2.SetActive(true);
            player4Point3.SetActive(false);
            player4WinScreen.SetActive(false);
        }
        else if (ScoreManager.player4Score == 3)
        {
            player4Point1.SetActive(true);
            player4Point2.SetActive(true);
            player4Point3.SetActive(true);
            player4WinScreen.SetActive(true);
        }
    }
}