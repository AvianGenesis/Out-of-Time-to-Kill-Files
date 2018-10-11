using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

    public float health;
    public float flow;
    public float loc;

    private float tick = 0;
    private GameObject controlPanel;
    private Text bossHP;
    private bool absB, slDnB;
    //private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        flow = 1f;
        loc = 0f;
        health = 60000f;
        absB = false;
        slDnB = false;

        controlPanel = GameObject.Find("Boss");
        bossHP = GameObject.Find("Boss HP").GetComponent<Text>();
        //rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        loc += (Mathf.PI / 150) * flow;
        transform.position = new Vector3(transform.position.x, (float)Mathf.Sin(loc) * 2, 0f);
        health = health - (4 * flow);

        tick += (1 * flow);
        if (tick > (230f - (180f * (1f - (health / 60000f)))))
        {
            tick = 0;
            int atkNum = Random.Range(0, 4);
            if (atkNum == 0)
            {
                controlPanel.GetComponent<BulletPatterns>().Sun1(transform.position);
            }

            if (atkNum == 1)
            {
                controlPanel.GetComponent<BulletPatterns>().Shotgun1(transform.position);
            }

            if (atkNum == 2)
            {
                controlPanel.GetComponent<BulletPatterns>().Sun2(transform.position);
            }

            if (atkNum == 3)
            {
                controlPanel.GetComponent<BulletPatterns>().Swirl1(transform.position);
            }
        }

        //Trigger detection
        if(absB && slDnB)
        {
            flow = 1f;
        }
        else if(absB)
        {
            flow = 2f;
        }
        else if(slDnB)
        {
            flow = 0.75f;
        }
        else
        {
            flow = 1f;
        }

        bossHP.text = "Boss HP: " + health;
	}


    private void OnTriggerEnter2D(Collider2D collision)
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
