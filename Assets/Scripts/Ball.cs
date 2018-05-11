﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {

    public Paddle Paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    private Rigidbody2D body2D;

    // Use this for initialization
    void Start ()
    {
        body2D = GetComponent<Rigidbody2D>();

        if(Paddle == null)
        {
            Paddle = FindObjectOfType<Paddle>();
        }
        
        paddleToBallVector = this.transform.position - Paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!hasStarted)
        {
            this.transform.position = Paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                body2D.velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
        }
	}
}
