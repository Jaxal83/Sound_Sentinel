﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBalls : MonoBehaviour {
    public GameObject ball;
    public float frequency;
    public float start_speed;

    //private int numberOfBalls = 0;
    private Vector3 target;
    private float target_x = 0;
    private float target_y = 0;
    private float x = 0;
    private float y = 0;
    private readonly float z = 30;

    private float speed;
    private float timer = 0;

    private const int MAX_x = 15;
    private const int MAX_y = 15;
    private const float MAX_targetx = 2;
    private const float MAX_targety = (float)0.5;
    private const int MAX_Speed = 10;

    // Use this for initialization
    void Start () {
        speed = start_speed;
	}
	
	// Update is called once per frame
	void Update () {
        //Check score

        //Have score determine if a new ball should be launched
        //what algorithm could I use??

        timer -= Time.deltaTime;
        //start_speed = speed;

        
        if(timer <= 0f)
        {
            GameObject temp = Instantiate(ball, new Vector3(Random.Range(-x,x), Random.Range(-y,y), z), Quaternion.identity) as GameObject;
            Rigidbody rb = temp.gameObject.GetComponent<Rigidbody>();
            DestroyBall tempscript = temp.gameObject.GetComponent<DestroyBall>();

            target = new Vector3(Random.Range(-target_x, target_x), Random.Range(-target_y+1, target_y+1), 0);

            var heading = target - temp.transform.position; 

            rb.velocity = ((heading / heading.magnitude) * speed);
            rb.velocity = heading.normalized * speed;
            tempscript.UpdateSpeed(speed);

            //numberOfBalls += 1;
            if (speed < MAX_Speed)
                speed += (float)0.2;
            if (x < MAX_x)
                x += (float)0.5;
            if (y < MAX_y)
                y += (float)0.5;
            if (frequency > 0.001)
                frequency -= (float)0.01;
            if (target_x < MAX_targetx)
                target_x += (float)0.1;
            if (target_y < MAX_targety)
                target_y += (float)0.1;

            timer = Random.Range(0, frequency);
        }
    }

    private void OnApplicationQuit()
    {
        TestingResults temp = GameObject.FindGameObjectWithTag("Testing").GetComponent<TestingResults>();
        temp.TestRecords("CreateBalls", true);
    }
}