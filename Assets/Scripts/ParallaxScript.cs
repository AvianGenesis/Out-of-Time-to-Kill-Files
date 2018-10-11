using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {

    private Vector2 loc;

    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - speed, 0f);

        if(transform.position.x <= -16f)
        {
            transform.position = new Vector2(16f, 0f);
        }
	}
}
