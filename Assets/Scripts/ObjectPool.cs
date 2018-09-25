using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public GameObject[] bullets;
	// Use this for initialization
	void Start () {
        bullets = new GameObject[100];
        for (int i = 0; i < 99; i++)
        {
            bullets[i] = GameObject.Find("Bullet");
        }
	}
	
	
}
