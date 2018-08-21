using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float minV = 2f;
    [SerializeField] float MaxV = 15f;

    bool hasStarted = false;
    Vector2 PaddleToBallVector;
	// Use this for initialization
	void Start ()
    {
        PaddleToBallVector = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
        }

        if(hasStarted == false)
        {
            LockBallToPaddle();
        }

        else if(hasStarted == true)
        {
            LaunchBallOnMouseClick();
        }

       
    }

    private void LaunchBallOnMouseClick()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(minV, MaxV);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePositon = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePositon + PaddleToBallVector;
    }
}


