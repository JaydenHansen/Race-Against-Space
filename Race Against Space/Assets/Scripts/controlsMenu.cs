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
        if (XCI.GetButtonDown(XboxButton.Start, controller))
        {
            Time.timeScale = 1;
        }
	}
}
