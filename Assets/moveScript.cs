using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed;
    public float rotationSpeed;
    public Rigidbody2D ball;

    public float ballAngle;

    public Vector2 angularVelocity;
    
    public bool isP1Punch;


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ballAngle = ball.rotation;
        

        angularVelocity.x = 1;
        angularVelocity.y = 0;
        

        //Player One
        if (Input.GetKey(KeyCode.A))
        {
            float rotateUp = 1 * rotationSpeed;
            //ball.MoveRotation(ballAngle + rotationSpeed * rotateUp * Time.fixedDeltaTime);

            ball.AddTorque(rotateUp, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Player One Punch
            isP1Punch = true;
            animator.SetBool("IsAttacking", isP1Punch);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isP1Punch = false;
            animator.SetBool("IsAttacking", isP1Punch);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float rotateDown = -1 * rotationSpeed;
            //ball.MoveRotation(ballAngle + rotationSpeed * rotateDown * Time.fixedDeltaTime);

            ball.AddTorque(rotateDown, ForceMode2D.Force);
        }

       



        ball.AddRelativeForce(angularVelocity * moveSpeed, ForceMode2D.Force);

        //Quit
        if (Input.GetKey(KeyCode.Escape))
        {

        }

        //Restart
        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Space))
        {

        }

        /*
        //Start Game
        if (Input.anyKeyDown)
        {

        }
        */
    }
}
