using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float flow;
    public float speed;
    public float velX;
    public float velY;
    public float angle;
    public bool isActive;

    private Rigidbody2D rb;
    private bool absB, slDnB;

    // Use this for initialization
    void Start()
    {
        flow = 1f;
        absB = false;
        slDnB = false;

        rb = GetComponent<Rigidbody2D>();
    }

    public void DrawBullet(float spd, float ang, Vector3 pos)
    {
        speed = spd;
        angle = ang;
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        velX = speed * (float)Mathf.Sin(angle) * flow;
        velY = speed * (float)Mathf.Cos(angle) * flow;
        rb.velocity = new Vector2(velX, velY);

        if (gameObject.activeInHierarchy && (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 6 || transform.position.y < -6))
        {
            gameObject.SetActive(false);
            flow = 1f;
        }

        //Trigger detection
        if (absB && slDnB)
        {
            flow = 1f;
        }
        else if (absB)
        {
            flow = 1.3f;
        }
        else if (slDnB)
        {
            flow = 0.2f;
        }
        else
        {
            flow = 1f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Absorb"))
        {
            absB = true;
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("SlowDown"))
        {
            slDnB = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Absorb"))
        {
            absB = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("SlowDown"))
        {
            slDnB = false;
        }
    }
}
