using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p2Move : MonoBehaviour
{
    public Animator p2animator;
    public float p2moveSpeed;
    public float p2Boost;
    public float p2rotationSpeed;

    public Rigidbody2D p2Ball;

    public float p2BallAngle;

    public Vector2 p2angularVelocity;
    
    public bool isp2Punch;
    public bool isp2Punching;

    public float p2punchLength = 2;
    public float p2punchTimer = 4;

    private float p2whenCanPunch;
    private float p2punchDuration;

    public Text p2HealthBox;
    public int p2Health;


    // Start is called before the first frame update
    void Start()
    {
        p2HealthBox.text = p2Health.ToString();

        p2Ball = GetComponent<Rigidbody2D>();

        isp2Punching = false;

        p2whenCanPunch = Time.time;

        p2Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        p2HealthBox.text = p2Health.ToString();

        if (p2Health <= 0)
        {

        }
        p2BallAngle = p2Ball.rotation;


        p2angularVelocity.x = -1 * p2Boost;
        p2angularVelocity.y = 0;

        //rotations
        if (Input.GetKey(KeyCode.J))
        {
            float p2rotateUp = 1 * p2rotationSpeed;      

            p2Ball.AddTorque(p2rotateUp, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.L))
        {
            float p2rotateDown = -1 * p2rotationSpeed;

            p2Ball.AddTorque(p2rotateDown, ForceMode2D.Force);
        }



        if (Time.time > p2whenCanPunch)
        {
            //starting the punch
            if (Input.GetKeyDown(KeyCode.K))
            {
                isp2Punching = true;
                p2punchDuration = Time.time + p2punchLength;
            }

            // during the punch
            if (Input.GetKey(KeyCode.K) && isp2Punching && Time.time < p2punchDuration)
            {
                //anim

                isp2Punch = true;
                p2Ball.AddRelativeForce(p2angularVelocity, ForceMode2D.Force);
            }

            // stop punching
            if (Input.GetKeyUp(KeyCode.K) && isp2Punching)
            {
                Debug.Log("stop");

                p2whenCanPunch = Time.time + p2punchTimer;
                isp2Punching = false;
                p2punchDuration = Time.time - 1;

                isp2Punch = false;
                //animation
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

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<moveScript>().p1Health--;
    }

}
