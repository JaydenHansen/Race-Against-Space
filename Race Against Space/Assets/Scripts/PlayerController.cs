using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rigidBody;
    public Rigidbody otherPlayer;
    public XboxController controller;

    public float movementSpeed = 10.0f;
    public float maxSpeed = 8.0f;
    public float jump = 125.0f;
    public float energy = 100.0f; 
    public bool isGrounded = false;
    public bool canPunch = false; 
    public Vector3 punchLeft = new Vector3(-100, 100, 0);
    public Vector3 punchRight = new Vector3(100, 100, 0);


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        if (other.gameObject.tag == "NotKillObsticle")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "energyReplenish")
        {
            energy = energy + 10;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPunch = true;
            otherPlayer = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(UnityEngine.Collision other)
    {
        if (other.gameObject.tag == "NotKillObsticle")
        {
            isGrounded = false;
        }
        if(other.gameObject.tag == "Player")
        {
            canPunch = false; 
        }
    }

    void punch()
    {
        if (canPunch)
        {
            if (XCI.GetButton(XboxButton.RightBumper, controller))
            {
                otherPlayer.AddForce(punchRight);
            }
            if (XCI.GetButton(XboxButton.LeftBumper, controller))
            {
                otherPlayer.AddForce(punchLeft);
            }
        }
    }
    void FixedUpdate()
    {
        MovePlayer();
        punch();
    }

    private void MovePlayer()
    {
        energy -= Time.deltaTime;
        print(energy);
        float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);

        Vector3 movement = new Vector3(axisX, 0, 0);

        if(rigidBody.velocity.magnitude < maxSpeed)
        {
            rigidBody.AddForce(movement * movementSpeed);
        }

        if (XCI.GetButton(XboxButton.A, controller) && isGrounded)
        {
            rigidBody.AddForce(new Vector3(0, jump, 0));
        }
        //Ensure the player can’t go faster than the max speed
        //if (rigidBody.velocity.magnitude > maxSpeed)
        //{
        //    rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
        //}

    }
}

