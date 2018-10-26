using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyReduce : MonoBehaviour {

    public PlayerController playerMove;
    float e; 
    // Use this for initialization
    private Vector3 originalPosition;
    private void Awake()
    {
        originalPosition = transform.position;
    }
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        e = playerMove.energy;
        //transform.Translate(new Vector3(-(e/100), 0, 0) * Time.deltaTime);
        transform.Translate(new Vector3(-(0.15f), 0, 0) * Time.deltaTime);


        //transform.Translate(new Vector3((originalPosition.x - e), 0, 0));
        //if(e <= 100 && e > 80)
        //{
        //    transform.Translate(originalPosition);
        //}
        //if (e <= 80 && e > 60)
        //{
        //    transform.Translate(new Vector3(((originalPosition.x - 1) / 10), 0, 0) * Time.deltaTime);
        //}
        //if (e <= 60 && e > 40)
        //{
        //    transform.Translate(new Vector3(((originalPosition.x - 2) / 10), 0, 0) * Time.deltaTime);
        //}
        //if (e <= 40 && e > 20)
        //{
        //    transform.Translate(new Vector3(((originalPosition.x - 3) / 10), 0, 0) * Time.deltaTime);
        //}
        //if (e <= 20 && e >= 0)
        //{
        //    transform.Translate(new Vector3(((originalPosition.x - 2) / 10), 0, 0) * Time.deltaTime);
        //}
    }
}
