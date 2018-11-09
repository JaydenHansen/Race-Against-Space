using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerActive : MonoBehaviour {

    public GameObject player;
    public GameObject objects;
    public bool playerActive; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            objects.gameObject.SetActive(player.gameObject.activeInHierarchy);
        }
    }
}
