using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float minV = 2f;
    [SerializeField] float MaxV = 15f;
    [SerializeField] AudioClip[] ballSounds;

    bool hasStarted = false;
    Vector2 PaddleToBallVector;

    AudioSource myAudioSource;
	// Use this for initializatio
	void Start ()
    {
        PaddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
        if (hasStarted)
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}


