using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ReturnToCharacterSelect()
    {
        SceneManager.LoadScene(1);
    }
}