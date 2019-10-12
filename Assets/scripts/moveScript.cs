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

    public Text p1HealthBox;
    public int p1Health;


    // Start is called before the first frame update
    void Start()
    {
        p1HealthBox.text = p1Health.ToString();

        ball = GetComponent<Rigidbody2D>();

        isPunching = false;

        whenCanPunch = Time.time;

        p1Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        p1HealthBox.text = p1Health.ToString();

        if (p1Health <= 0)
        {
            // p2 wins
        }

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
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("astroDude_2"))
        {
            collider.GetComponent<p2Move>().p2Health--;            
        }
    }

}
