using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    public Rigidbody otherPlayer;

    public XboxController controller;
    public GameObject controlsMenu;

    public float movementSpeed = 10.0f;
    public float maxSpeed = 8.0f;
    public float jump = 125.0f;

    public float energy = 100.0f; 

    public bool isGrounded;
    public bool paused = false;
    public float lengthOfRaycast = 2.0f;

    public bool canPunch = false; 
    public Vector3 punchLeft = new Vector3(-100, 100, 0);
    public Vector3 punchRight = new Vector3(100, 100, 0);


    void Start()
    {
        //gets the rigidbody of the player
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 rayDir = transform.TransformDirection(Vector3.down);
        RaycastHit rayHit;

        isGrounded = Physics.Raycast(transform.position, rayDir, out rayHit, lengthOfRaycast);
        pauseGame();
    }
    //void OnCollisionEnter(Collision other)
    //{
    //if (other.gameObject.tag == "energyReplenish")
    //{//if the object is an energy replenish the player gets some energy returned
    //   energy = energy + 10;
    // }
    // }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {//if the player is detected colliding with another player sets punch to true and gets the rigidbody of the other player
            canPunch = true;
            otherPlayer = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {//if the other player has left the collision the player is unable to punch
            canPunch = false; 
        }
    }

    void PlayerPunch()
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
    void pauseGame()
    {
        if (XCI.GetButtonDown(XboxButton.Start, controller) && !paused)
        {//if start button is pressed while game is running it will pause the game and bring up the controls menu
            Time.timeScale = 0;
            controlsMenu.SetActive(true);
            paused = true; 
        }
        else if(XCI.GetButtonDown(XboxButton.Start, controller) && paused)
        {//if start button is pressed while paused the game will resume 
            Time.timeScale = 1;
            controlsMenu.SetActive(false);
            paused = false; 
        }
    }

    private void MovePlayer()
    {
        energy -= Time.deltaTime * 1.6f;
        //makes the energy decrease over time
        //print(energy);
        //prints energy to the console to show the energy decreasing
        float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);

        Vector3 movement = new Vector3(axisX, 0, 0);

        rigidBody.AddForce(movement * movementSpeed);
        Debug.Log(rigidBody.velocity.magnitude);
        Vector3 velocity = rigidBody.velocity;
        if(velocity.x > maxSpeed)
        {
            velocity.x = maxSpeed;
        }
        if(velocity.x < -maxSpeed)
        {
            velocity.x = -maxSpeed;
        }
        rigidBody.velocity = velocity;

        //if(rigidBody.velocity.magnitude > maxSpeed)
        //{
        //    rigidBody.velocity = rigidBody.velocity.normalized;
        //    rigidBody.velocity *= maxSpeed;
        //}

        if (XCI.GetButtonDown(XboxButton.A, controller) && isGrounded)
        //if the "a" button is pressed you can jump as long as you are grounded
        {
            rigidBody.AddForce(new Vector3(0, jump, 0));
        }
    }
    void CheckIfPlayerIsAlive()
    {
        if(energy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        MovePlayer();
        PlayerPunch();
        CheckIfPlayerIsAlive(); 
    }
}

