using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p2Move : MonoBehaviour
{
    public Animator p2animator;

    public float p2moveSpeed;
    public float p2rotationSpeed;
    public float jumpHeight;
    public Rigidbody2D p2Ball;

    public float p2BallAngle;

    public Vector2 p2angularVelocity;

    public float tracker;

    public bool isp2Punch;


    // Start is called before the first frame update
    void Start()
    {
        p2Ball = GetComponent<Rigidbody2D>();

        p2moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        p2BallAngle = p2Ball.rotation;


        p2angularVelocity.x = -1;
        p2angularVelocity.y = 0;


        //Player One
        if (Input.GetKey(KeyCode.J))
        {
            float rotateUp = 1;
            p2Ball.MoveRotation(p2BallAngle + p2rotationSpeed * rotateUp * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.K))
        {
            //Player One Punch
            isp2Punch = true;
            p2animator.SetBool("IsAttacking", isp2Punch);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            isp2Punch = false;
            p2animator.SetBool("IsAttacking", isp2Punch);
        }
        if (Input.GetKey(KeyCode.L))
        {
            float rotateDown = -1;
            p2Ball.MoveRotation(p2BallAngle + p2rotationSpeed * rotateDown * Time.fixedDeltaTime);
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
