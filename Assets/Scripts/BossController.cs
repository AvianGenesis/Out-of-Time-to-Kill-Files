using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    public float health;
    public float flow;
    public float loc;

    //private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        flow = 1f;
        loc = 0f;
        //rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        loc += (Mathf.PI / 200) * flow;
        transform.position = new Vector3(transform.position.x, (float)Mathf.Sin(loc) * 2, 0f);
	}
}
