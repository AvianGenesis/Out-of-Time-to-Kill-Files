using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float health;
    public float flow;
    public float speed;
    public float velX;
    public float velY;
    public float score;
    public float energy;

    private Vector3 resetPosition;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        health = 5f;
        flow = 1f;
        speed = 7f;

        resetPosition = transform.position;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Damage") || collision.gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            health--;
            transform.position = resetPosition;
        }
    }
}
