using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class moveScript : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public float boost;
    public float rotationSpeed;

    public Rigidbody2D ball;

    public float ballAngle;

    public Vector2 angularVelocity;
    
    public bool isP1Punch;
    public bool isPunching;

    public float punchLength = 2;
    public float punchTimer = 4;

    private float whenCanPunch;
    private float punchDuration;


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();

        isPunching = false;

        whenCanPunch = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ballAngle = ball.rotation;
        

        angularVelocity.x = 1 * boost;
        angularVelocity.y = 0;
        
        

        //rotations
        if (Input.GetKey(KeyCode.A))
        {
            float rotateUp = 1 * rotationSpeed;
            
            ball.AddTorque(rotateUp, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float rotateDown = -1 * rotationSpeed;
            //ball.MoveRotation(ballAngle + rotationSpeed * rotateDown * Time.fixedDeltaTime);

            ball.AddTorque(rotateDown, ForceMode2D.Force);
        }


        if (Time.time > whenCanPunch)
        {
            //starting the punch
            if(Input.GetKeyDown(KeyCode.S))
            {
                isPunching = true;
                punchDuration = Time.time + punchLength;
            }

            // during the punch
            if (Input.GetKey(KeyCode.S) && isPunching && Time.time < punchDuration)
            {
                //animator
                animator.SetBool("IsAttacking", isP1Punch);

                //Player One Punch
                isP1Punch = true;
                ball.AddRelativeForce(angularVelocity, ForceMode2D.Force);
            }            

            // stop punching
            if (Input.GetKeyUp(KeyCode.S) && isPunching)
            {
                whenCanPunch = Time.time + punchTimer;
                isPunching = false;
                punchDuration = Time.time - 1;

                isP1Punch = false;
                animator.SetBool("IsAttacking", isP1Punch);
            }
        }
        

        

       



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
