using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //sets an character controller
    private CharacterController controller;
    //sets where the player is moving to
    private Vector3 direction;
    //sets how fast the player moves forward and side to side
    public float forwardSpeed, turnSpeed, jumpForce, gravity;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Claire.DamageManager.isDead)
        {
            //increase movement speed as the game continues
            forwardSpeed += Time.deltaTime / 10;
            turnSpeed += Time.deltaTime / 20;
            //uses input to make the player activate jump function if they are on the ground
            if (Input.GetKeyDown(KeyCode.UpArrow) && controller.isGrounded)
            {
                gravity = 20f;
                Jump();
            }
            if (Input.GetKey(KeyCode.UpArrow) && !controller.isGrounded)
            {
                //slows gravity when gliding
                direction.y -= gravity * Time.deltaTime / 2;
                gravity += Time.deltaTime;
            }
            else
            {
                //changes direction to move player down
                direction.y -= gravity * Time.deltaTime;
                gravity += Time.deltaTime;
            }

            //sets direction forward so player has to move forward
            direction.z = forwardSpeed;
            //sets direction so player can move to the right and left
            direction.x = Input.GetAxis("Horizontal") * turnSpeed;
        }
        else
        {
            forwardSpeed = 0;
            turnSpeed = 0;
            direction = Vector3.zero;
        }
       
    }
    private void Jump()
    {
        //changes direction to make the player move up
        direction.y = jumpForce;
    }
    private void FixedUpdate()
    {
        //moves player towards direction
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
