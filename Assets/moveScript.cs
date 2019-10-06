using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float jumpHeight;
    public Rigidbody2D ball;

    public float ballAngle;

    public Vector2 angularVelocity;

    public float tracker;


    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        tracker = Input.GetAxis("Vertical") * moveSpeed;

        ballAngle = ball.rotation;
        ball.MoveRotation(ballAngle + rotationSpeed * tracker * Time.fixedDeltaTime);

        if(ballAngle > 360){
            ballAngle -= 360;
        }else if(ballAngle < 0){
            ballAngle += 360;
        }

// velocity
        if(ballAngle == 0){
            angularVelocity.x = moveSpeed;
            angularVelocity.y = 0;
        }
        if(ballAngle < 90){

        }
        if(ballAngle == 90){
            angularVelocity.x = 0;
            angularVelocity.y = moveSpeed;
        }
        if(ballAngle < 180 && ballAngle > 90){
            
        }
        if(ballAngle == 180){
            angularVelocity.x = -1 * moveSpeed;
            angularVelocity.y = 0;
        }
        if(ballAngle < 270 && ballAngle > 180){
            
        }
        if(ballAngle == 270){
            angularVelocity.x = 0;
            angularVelocity.y = -1 * moveSpeed;
        }
        if(ballAngle < 360 && ballAngle > 270){
            
        }
        if(ballAngle == 360){
            angularVelocity.x = moveSpeed;
            angularVelocity.y = 0;
        }

        ball.velocity = angularVelocity;
    }
}
