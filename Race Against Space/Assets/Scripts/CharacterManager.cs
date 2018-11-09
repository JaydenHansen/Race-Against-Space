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
    // Use this for initialization

    public static bool[] isPlaying = new bool[4];//has a bool playing function so it will load only active players

	void Start () {
        playersActive = 0; 
        characters = new List<GameObject>();
        foreach(Transform t in transform)
        {
            characters.Add(t.gameObject);//adds all the players to the array of characters 
            t.gameObject.SetActive(false);
        }
	}

    public void Select(int index)
    {
        selectionIndex = index;
        if (characters[selectionIndex].activeInHierarchy)
        {//if the character is active and selected again they will be unselected
            isPlaying[index] = false; 
            characters[selectionIndex].SetActive(false);
            playersActive = playersActive - 1;//keeps count of active players
        }
        else if (!characters[selectionIndex].activeInHierarchy)
        {//if the character is selected while inactive they will be activated and selected
            isPlaying[index] = true;
            characters[selectionIndex].SetActive(true);
            playersActive = playersActive + 1; //keeps count of active players
        }
    }

    public void LoadPlayer()
    {
        //selects players based on keys, will need to be changed when access to four controllers is granted
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Select(0);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Select(1);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Select(2);
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Select(3);
        //}
        if (XCI.GetButtonDown(XboxButton.A, controller1))
        {
            Select(0);
        }
        if (XCI.GetButtonDown(XboxButton.A, controller2))
        {
            Select(1);
        }
        if (XCI.GetButtonDown(XboxButton.A, controller3))
        {
            Select(2);
        }
        if (XCI.GetButtonDown(XboxButton.A, controller4))
        {
            Select(3);
        }
        //if (Input.GetKeyDown(KeyCode.Escape) && playersActive > 1)
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
        }
        else
        {//only uses this when in main game
            activateActivePlayer();
        }
    }
}
