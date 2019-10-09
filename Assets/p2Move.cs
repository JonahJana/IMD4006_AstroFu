using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Move : MonoBehaviour
{
    public Animator p2animator;

    public float p2moveSpeed;
    public float p2rotationSpeed;
    public Rigidbody2D p2Ball;

    public float p2BallAngle;

    public Vector2 p2angularVelocity;
    
    public bool isp2Punch;

    public float torque;


    // Start is called before the first frame update
    void Start()
    {
        p2Ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        p2BallAngle = p2Ball.rotation;


        p2angularVelocity.x = -1;
        p2angularVelocity.y = 0;

        //float p2rotateUp = 3;
        //p2Ball.MoveRotation(p2BallAngle + p2rotationSpeed * p2rotateUp * Time.fixedDeltaTime);
        //Player One
        if (Input.GetKey(KeyCode.J))
        {
            float p2rotateUp = 1 * p2rotationSpeed;
            //p2Ball.MoveRotation(p2BallAngle + p2rotationSpeed * p2rotateUp * Time.fixedDeltaTime);
            torque = p2rotateUp;

            p2Ball.AddTorque(p2rotateUp, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.K))
        {
            //Player One Punch
            isp2Punch = true;
            //p2animator.SetBool("IsAttacking", isp2Punch);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            isp2Punch = false;
            //p2animator.SetBool("IsAttacking", isp2Punch);
        }
        if (Input.GetKey(KeyCode.L))
        {
            float p2rotateDown = -1 * p2rotationSpeed;
            //p2Ball.MoveRotation(p2BallAngle + p2rotationSpeed * p2rotateDown * Time.fixedDeltaTime);
            torque = p2rotateDown;

            p2Ball.AddTorque(p2rotateDown, ForceMode2D.Force);
        }



        p2Ball.AddRelativeForce(p2angularVelocity * p2moveSpeed, ForceMode2D.Force);

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
