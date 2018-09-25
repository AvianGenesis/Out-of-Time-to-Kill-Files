using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float flow;
    public float speed;
    public float velX;
    public float velY;
    public float angle;
    public bool isActive;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        flow = 1f;
        isActive = false;
        
        rb = GetComponent<Rigidbody2D>();
	}
	
    public void CreateBullet (float spd, float ang, Vector3 pos)
    {
        speed = spd;
        angle = ang;
        transform.position = pos;
    }

	// Update is called once per frame
	void Update () {
        velX = speed * (float)Mathf.Sin(angle) * flow;
        velY = speed * (float)Mathf.Cos(angle) * flow;
        rb.velocity = new Vector2(velX, velY);
	}
}
