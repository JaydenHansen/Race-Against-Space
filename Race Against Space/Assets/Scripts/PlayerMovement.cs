using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


public class PlayerMovement : MonoBehaviour {

	public float timer;
	public float speed;
    public float energy; 
    public GameObject wallsAndFloors; 
    public bool jump; 
	private Rigidbody rb;
	void Awake(){
		print ("Awake Function");
	}
	// Use this for initialization
	void Start () {
		print("Start Function");
		rb = gameObject.GetComponent<Rigidbody>();
		speed = 10.0f;
        jump = false;
        energy = 100.0f; 
	}

    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if(other.gameObject.tag == "NotKillObsticle")
        {
            jump = true; 
        }
        if (other.gameObject.tag == "energyReplenish")
        {
            energy = energy + 10; 
        }
    }
    private void OnCollisionExit(UnityEngine.Collision other)
    {
        if(other.gameObject.tag == "NotKillObsticle")
        {
            jump = false; 
        }
    }

    // Update is called once per frame
    void Update () 
    {
        energy -= Time.deltaTime * 1.6f;
        print(energy);
		if(Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(new Vector3(3, 0, 0));
        }
		if(Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(new Vector3(-3, 0, 0));
        }
        if ((jump) && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.AddForce(new Vector3(0, 150, 0));
        }
        if ((Input.GetKeyDown(KeyCode.Q)) && energy > 0)
        {
            energy = energy - 5;
            rb.AddForce(new Vector3(-50, 80, 0));
        }
        if ((Input.GetKeyDown(KeyCode.E)) && energy > 0)
        {
            energy = energy - 5;
            rb.AddForce(new Vector3(50, 80, 0));
        }
	}
}