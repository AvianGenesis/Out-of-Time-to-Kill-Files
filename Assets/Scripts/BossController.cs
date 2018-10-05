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
    //private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        flow = 1f;
        loc = 0f;
        health = 30000f;

        controlPanel = GameObject.Find("Boss");
        bossHP = GameObject.Find("Boss HP").GetComponent<Text>();
        //rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        loc += (Mathf.PI / 200) * flow;
        transform.position = new Vector3(transform.position.x, (float)Mathf.Sin(loc) * 2, 0f);
        health = health - (1 * flow);

        tick = tick + (1 * flow);
        if (tick > 230)
        {
            tick = 0;
            int atkNum = Random.Range(0, 2);
            if (atkNum == 0)
            {
                controlPanel.GetComponent<BulletPatterns>().Sun1(transform.position);
            }

            if (atkNum == 1)
            {
                controlPanel.GetComponent<BulletPatterns>().Shotgun1(transform.position);
            }
        }
        bossHP.text = "Boss HP: " + health;
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Absorb"))
        {
            flow = 2f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Absorb"))
        {
            //health--;
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
