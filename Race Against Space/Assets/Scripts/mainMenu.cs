using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public void PlayGame()
    {
        //when play game is selected it loads the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        //if quit game is selected it quits game
        Application.Quit(); 
    }
    public void ReturnToMenu()
    {
        //if return to menu is selected load the first scene
        SceneManager.LoadScene(0);
    }
    public void ReturnToCharacterSelect()
    {
        //if return to character select is selected return to character select
        SceneManager.LoadScene(1);
    }
}