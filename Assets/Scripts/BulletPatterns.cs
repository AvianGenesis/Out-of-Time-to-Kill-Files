using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BulletControllerScript;

public class BulletPatterns : MonoBehaviour {

    private GameObject[] bullets = new GameObject[500];

    void Start()
    {
        for (int i = 0; i <= 399; i++)
        {
            bullets[i] = Resources.Load<GameObject>("Prefabs/Bullet");
            bullets[i].SetActive(false);
        }
    }

    private GameObject[] FindBullets(int numToFind)
    {
        GameObject[] soughtBullets = new GameObject[numToFind];
        int tick = 0;

        for (int i = 0; i <= 299; i++)
        {
            if (!bullets[i].GetComponent<BulletController>().isActive)
            {
                bullets[i].GetComponent<BulletController>().isActive = true;
                bullets[i].SetActive(true);
                soughtBullets[tick] = bullets[i];
                if(tick == numToFind - 1)
                {
                    return soughtBullets;
                }
                tick++;
            }
        }
        return soughtBullets;
    }

    public void Shotgun1()
    {
    //put 30 bullets into array
    //iterate 10 at a time, 3 times
    //each 10 have same trajectory but different speeds
    //aimed directly to the left
    }

    public void Swirl1()
    {
        //put 36 bullets
        //iterate through, activating one every few frames
        //wave pattern between 0 and 180 to the left
    }

    public void Sun1(Vector3 pos)
    {
        GameObject[] magazine;
        magazine = FindBullets(36);

        for (int i = 0; i <= 35; i++)
        {
            magazine[i].GetComponent<BulletController>().CreateBullet(7f, Mathf.PI * (36 / i), new Vector3(pos.x, pos.y));
        }
    }
}
