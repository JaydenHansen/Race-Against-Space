using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rigidBody;
    public Rigidbody otherPlayer;
    public XboxController controller;
    public GameObject controlsMenu;
    public GameObject player;
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
        //gets the rigidbody of the player
        player = this.gameObject;
        rigidBody = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(UnityEngine.Collision other)
    {
        //checks the tags of the objects colliding with the player
        if (other.gameObject.tag == "NotKillObsticle")
        {//if the object is a not kill obsticle isGrounded is set to true to allow jumping 
            isGrounded = true;
        }
        if (other.gameObject.tag == "energyReplenish")
        {//if the object is an energy replenish the player gets some energy returned
            energy = energy + 10;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {//if the player is detected colliding with another player sets punch to true and gets the rigidbody of the other player
            canPunch = true;
            otherPlayer = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(UnityEngine.Collision other)
    {
        if (other.gameObject.tag == "NotKillObsticle")
        {//once the player is no longer colliding with the not kill obsticle isGrounded is set to false
            isGrounded = false;
        }
        if(other.gameObject.tag == "Player")
        {//if the other player has left the collision the player is unable to punch
            canPunch = false; 
        }
    }

    void punch()
    {
        if (canPunch)
        {//if punch is true you are able to punch
            if (XCI.GetButton(XboxButton.RightBumper, controller))
            {//if right bumper is hit, hit the player to the right
                otherPlayer.AddForce(punchRight);
            }
            if (XCI.GetButton(XboxButton.LeftBumper, controller))
            {//if left bumper is hit, hit the player to the left
                otherPlayer.AddForce(punchLeft);
            }
        }
    }
    //public void checkRunning()
    //{
    //    if (Time.timeScale == 1)
    //    {
    //        controlsMenu.SetActive(false);
    //    }
    //    else
    //    {
    //        controlsMenu.SetActive(true);
    //    }
    //}
    //void pauseGame()
    //{
    //    if (XCI.GetButtonDown(XboxButton.Start, controller))
    //    {
    //        Time.timeScale = 0;
    //    }
    //}

    private void MovePlayer()
    {
        energy -= Time.deltaTime * 1.6f;
        //makes the energy decrease over time
        print(energy);
        //prints energy to the console to show the energy decreasing
        float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);

        Vector3 movement = new Vector3(axisX, 0, 0);

        if(rigidBody.velocity.magnitude < maxSpeed)
            //stops adding force if the player has reached max speed
        {
            rigidBody.AddForce(movement * movementSpeed);
        }

        if (XCI.GetButton(XboxButton.A, controller) && isGrounded)
        //if the "a" button is pressed you can jump as long as you are grounded
        {
            rigidBody.AddForce(new Vector3(0, jump, 0));
        }
    }
    void checkIfPlayerIsAlive()
    {
        if(energy <= 0)
        {
            Destroy(player);
        }
    }
    void FixedUpdate()
    {
        MovePlayer();
        punch();
        checkIfPlayerIsAlive(); 
        //pauseGame();
        //checkRunning(); 
    }
}

