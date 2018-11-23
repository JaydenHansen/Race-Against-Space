using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool facingRight = true;

    public Rigidbody rigidBody;
    public Rigidbody otherPlayer;

    public XboxController controller;

    public float playerEnergy = 100.0f;
    public float energyDecrease = 1.6f; 

    public float movementSpeed = 20.0f;
    public float maxSpeed = 20.0f;
    public float jumpPower = 12.5f;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    public bool isGrounded;
    public float jumpRayLength = 2.0f;

    public bool canPunch;
    public float punchRayLength = 2.0f;

    public float horizPunchPower = 100f;
    public float vertPunchPower = 100f;

    public Animator anim;

    // public float boostDuration = 2.0f;
    // private float boostTimer;
    // public float boostForce = 100f;

    public bool paused = false;
    public GameObject controlsMenu;

    public ParticleSystem jumpParticle;
    public ParticleSystem jumpParticle1;
    public ParticleSystem jumpParticle2;
    public ParticleSystem jumpParticle3;
    void Awake()
    {
        //gets the rigidbody of the player
        rigidBody = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (this != null)
        {

		    if (playerEnergy > 100) 
		    {
		    	playerEnergy = 100; 
		    }
        

            Vector3 jumpRayDir = transform.TransformDirection(Vector3.down);
            RaycastHit jumpRayHit;
            isGrounded = Physics.Raycast(transform.position, jumpRayDir, out jumpRayHit, jumpRayLength);

            Vector3 punchRayDir = transform.TransformDirection(Vector3.forward);
            RaycastHit punchRayHit;
            canPunch = Physics.Raycast(new Vector3(transform.position.x,(transform.position.y + 0.845f), transform.position.z), punchRayDir, out punchRayHit, punchRayLength);

            otherPlayer = punchRayHit.rigidbody;

		    MovePlayer();
            anim.SetBool("Jump", isGrounded);

            PauseGame();
        }
    }
    void PauseGame()
    {
        if (XCI.GetButtonDown(XboxButton.Start, controller) && !paused)
        {//if start button is pressed while game is running it will pause the game and bring up the controls menu
            Time.timeScale = 0;
            controlsMenu.SetActive(true);
            paused = true;
        }
        else if (XCI.GetButtonDown(XboxButton.Start, controller) && paused)
        {//if start button is pressed while paused the game will resume 
            Time.timeScale = 1;
            controlsMenu.SetActive(false);
            paused = false;
        }
    }

    void PlayerPunch()
    {
		if (canPunch) {//if punch is true you are able to punch
			if (XCI.GetButton (XboxButton.RightBumper, controller)) {
				anim.SetTrigger ("Punch");
				//anim.Play("Attack_01");
			}
			if (XCI.GetButton (XboxButton.X, controller) && facingRight) {//if right bumper is hit, hit the player to the right
				otherPlayer.AddForce (new Vector3 (horizPunchPower, vertPunchPower, 0));
			} else if (XCI.GetButton (XboxButton.X, controller) && !facingRight) {//if left bumper is hit, hit the player to the left
				otherPlayer.AddForce (new Vector3 (-horizPunchPower, vertPunchPower, 0));
			}
		} 
		else 
		{
			if (XCI.GetButton (XboxButton.RightBumper, controller))
				anim.SetTrigger ("Punch");
		}
    }

    private void MovePlayer()
    {
        playerEnergy -= Time.deltaTime * energyDecrease;
        //makes the energy decrease over time
        float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);

        Vector3 movement = new Vector3(axisX, 0, 0);

        rigidBody.AddForce(movement * movementSpeed);

        //if (axisX > 0 || axisX < 0)
        //{
        //    anim.Play("Run_01");
        //}
        //else if (axisX == 0)
        //{
        //    anim.Play("Idle");
        //}

        anim.SetFloat("Movement", movement.magnitude);

        Vector3 velocity = rigidBody.velocity;
        if (velocity.x > maxSpeed)
        {
            velocity.x = maxSpeed;
        }

        if (velocity.x < -maxSpeed)
        {
            velocity.x = -maxSpeed;
        }

        rigidBody.velocity = velocity;

        

        if (XCI.GetButtonDown(XboxButton.A, controller) && isGrounded)
        //if the "a" button is pressed you can jump as long as you are grounded
        {
            rigidBody.velocity = Vector2.up * jumpPower;

            if (this.gameObject.name.Equals("Mesh_Character_Full_01"))
            {
                jumpParticle.Play();
            }
            else if (this.gameObject.name.Equals("Mesh_Character_Full_01 (1)"))
            {
                jumpParticle1.Play();
            }
            else if (this.gameObject.name.Equals("Mesh_Character_Full_01 (2)"))
            {
                jumpParticle2.Play();
            }
            else if (this.gameObject.name.Equals("Mesh_Character_Full_01 (3)"))
            {

            }

        }

        // punch animation
        //if (XCI.GetButton(XboxButton.A, controller))
        //{
        //    anim.Play("Launch_01");
        //}

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidBody.velocity.y > 0 && !XCI.GetButton(XboxButton.A, controller))
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // else if (XCI.GetButton(XboxButton.A, controller) && !isGrounded)
        // {
        //     boostTimer -= Time.deltaTime;
        // 
        //     if (boostTimer > 0)
        //     {
        //         rigidBody.AddForce(new Vector3(0, boostForce, 0));
        //     }
        // }
        // 
        // if (isGrounded)
        // {
        //     boostTimer = boostDuration;
        // }

        if (axisX > 0 && !facingRight)
            Flip();
        else if (axisX < 0 && facingRight)
            Flip();
    }
    void CheckIfPlayerIsAlive()
    {
        if (playerEnergy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void FixedUpdate()
    {
        if (this != null)
        {
            PlayerPunch();
            CheckIfPlayerIsAlive();
        }
    }

}