using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class CharacterManager : MonoBehaviour {
    public List<GameObject> characters;
    //default index of the model
    private int selectionIndex = 0;
    private int i = 0;
    public bool isMain;
    static int playersActive;
    public XboxController controller1;
    public XboxController controller2;
    public XboxController controller3;
    public XboxController controller4;
	private LevelReset lvlReset;
    // Use this for initialization

    //has a bool playing function so it will load only active players
    public static bool[] isPlaying = new bool[4];

	void Start () {
        playersActive = 0; 
        characters = new List<GameObject>();
        foreach(Transform t in transform)
        {
            //adds all the players to the array of characters 
            characters.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
	}

    public void Select(int index)
    {
        selectionIndex = index;
        //if the character is active and selected again they will be unselected
        if (characters[selectionIndex].activeInHierarchy)
        {
            isPlaying[index] = false; 
            characters[selectionIndex].SetActive(false);
            //keeps count of active players
            playersActive = playersActive - 1;
        }
        //if the character is selected while inactive they will be activated and selected
        else if (!characters[selectionIndex].activeInHierarchy)
        {
            isPlaying[index] = true;
            characters[selectionIndex].SetActive(true);
            //keeps count of active players
            playersActive = playersActive + 1; 
        }
    }

    public void LoadPlayer()
    {
        //selects players based on keys, will need to be changed when access to four controllers is granted
        //if the first player presses a they become active
        if (XCI.GetButtonDown(XboxButton.A, controller1))
        {
            Select(0);
        }
        //if the second player presses a they become active
        if (XCI.GetButtonDown(XboxButton.A, controller2))
        {
            Select(1);
        }
        //if the third player presses a they become active
        if (XCI.GetButtonDown(XboxButton.A, controller3))
        {
            Select(2);
        }
        //if the fouyrth player presses a they become active
        if (XCI.GetButtonDown(XboxButton.A, controller4))
        {
            Select(3);
        }
        if(XCI.GetButtonDown(XboxButton.Start) && (playersActive > 1))
        {//loads next scene when ready
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void CheckPlayerActive()
    {//check if the players are active
        for(i = 0; i <4; i++)
        {//goes through the character array
            if (characters[i].activeInHierarchy)
            {
                isPlaying[i] = true;
            }
            else
            {
                isPlaying[i] = false; 
            }
        }
    }
    public void activateActivePlayer()
    {//if a characyer is playing set them to active
        for(i = 0; i < 4; i++)
        {
            if (isPlaying[i])
            {
                characters[i].SetActive(true);
            }
        }
    }
    // Update is called once per frame
    private void Update ()
    {
        if (!isMain)
        {//only uses these when in character selection mode
            LoadPlayer();
            CheckPlayerActive(); 
			ScoreManager.player1Score = 0;
			ScoreManager.player2Score = 0;
			ScoreManager.player3Score = 0;
			ScoreManager.player4Score = 0;
        }
        else
        {//only uses this when in main game
            activateActivePlayer();
        }
    }
}
