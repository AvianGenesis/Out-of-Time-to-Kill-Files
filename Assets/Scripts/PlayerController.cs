using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float flow;
    public float speed;
    public float velX;
    public float velY;
    public float score;
    public float energy;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        flow = 1f;
        speed = 7f;

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        velX = inputX * speed * flow;
        velY = inputY * speed * flow;

        rb.velocity = new Vector2(velX, velY);

	}
}
