using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour {
    private List<GameObject> characters;
    //default index of the model
    private int selectionIndex = 0;
    private int i = 0;
    public bool isMain;
    // Use this for initialization

    static bool[] isPlaying = new bool[4];

	void Start () {
        characters = new List<GameObject>();
        foreach(Transform t in transform)
        {
            characters.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        //characters[selectionIndex].SetActive(true); 
	}

    public void Select(int index)
    {
        selectionIndex = index;
        if (characters[selectionIndex].activeInHierarchy)
        {
            characters[selectionIndex].SetActive(false);
        }
        else if (!characters[selectionIndex].activeInHierarchy)
        {
            isPlaying[index] = true;
            characters[selectionIndex].SetActive(true);
        }
    }

    public void LoadPlayer()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Select(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Select(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Select(2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Select(3);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void CheckPlayerActive()
    {
        for(i = 0; i <4; i++)
        {
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
    {
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
        {
            LoadPlayer();
            CheckPlayerActive(); 
        }
        else
        {
            activateActivePlayer();
        }
    }
}
