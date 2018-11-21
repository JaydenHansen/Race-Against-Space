using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class controlsMenu : MonoBehaviour {

	// Use this for initialization
    public XboxController controller;
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //if start is pressed while the controls menu is active it will deactiveate it
        if (XCI.GetButtonDown(XboxButton.Start, controller))
        {
            //sets the timescale to 1 so it will resume the game 
            Time.timeScale = 1;
        }
	}
}
