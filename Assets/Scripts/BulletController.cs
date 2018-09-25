using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float flow;
    public float speed;
    public float velX;
    public float velY;
    public float angle;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        flow = 1f;
        
        rb = GetComponent<Rigidbody2D>();
	}
	
    void createBullet (float spd, float ang)
    {
        speed = spd;
        angle = ang;
    }

	// Update is called once per frame
	void Update () {
        velX = speed * (float)Mathf.Sin(angle) * flow;
        velY = speed * (float)Mathf.Cos(angle) * flow;
        rb.velocity = new Vector2(velX, velY);
	}
}
