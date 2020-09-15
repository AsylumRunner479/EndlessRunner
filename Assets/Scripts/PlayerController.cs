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
    public int lane = 0, laneDistance = 6;
    public GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = 4;
    }
    private void ChangeLanes(bool left)
    {
        if (left && lane < 2)
        {
            lane += 1;
        }
        else if (!left && lane > 0)
        {
            lane -= 1;
        }
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
            if (Input.GetKeyDown(KeyCode.LeftArrow) && controller.isGrounded)
            {
                ChangeLanes(true);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && controller.isGrounded)
            {
                ChangeLanes(false);
            }
           
            
            
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
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lane == 0)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        else if (lane == 2)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 8 * Time.deltaTime);
        
    }
}
