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
        
        rb = GetComponent<Rigidbody2D>();
	}
	
    public void DrawBullet (float spd, float ang, Vector3 pos)
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

        if(gameObject.activeInHierarchy && (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 6 || transform.position.y < -6))
        {
            gameObject.SetActive(false);
            flow = 1f;
            Debug.Log("Bullet destructed");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Absorb"))
        {
            flow = 1.3f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Absorb"))
        {
            flow = 1f;
        }
    }
}
