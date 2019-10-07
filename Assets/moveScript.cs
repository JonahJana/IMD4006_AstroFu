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

        moveSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        tracker = Input.GetAxis("Vertical") * moveSpeed;

        ballAngle = ball.rotation;
        ball.MoveRotation(ballAngle + rotationSpeed * tracker * Time.fixedDeltaTime);

        angularVelocity.x = 1;
        angularVelocity.y = 0;


        ball.AddRelativeForce(angularVelocity * moveSpeed, ForceMode2D.Force);

        //ball.MovePosition((Vector2)transform.position + ((Vector2)transform.forward * moveSpeed));
    }
}
