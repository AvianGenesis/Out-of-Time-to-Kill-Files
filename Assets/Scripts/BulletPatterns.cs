using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using BulletControllerScript;

public class BulletPatterns : MonoBehaviour {

    private GameObject[] bullets;

    void Start()
    {
        bullets = new GameObject[500];
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Bullet");
        
        for (int i = 0; i <= 399; i++)
        {
            bullets[i] = Instantiate<GameObject>(prefab);
            bullets[i].SetActive(false);
        }

    }


    private void Update()
    {

    }

    private GameObject[] FindBullets(int numToFind)
    {

        GameObject[] soughtBullets = new GameObject[numToFind];
        int tick = 0;

        for (int i = 0; i <= 299; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
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

    public void Shotgun1(Vector3 pos, Vector3 target)
    {
        GameObject[] magazine;
        magazine = FindBullets(30);

        for (int i = 0; i <= 9; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(2f * ((i + 1f) / 10f) + 3, 2f * Mathf.PI * (7f / 9f), new Vector3(pos.x, pos.y));
        }

        for (int i = 10; i <= 19; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(2f * ((i - 9f) / 10f) + 3, 2f * Mathf.PI * (3f/4f), new Vector3(pos.x, pos.y));
        }

        for (int i = 20; i <= 29; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(2f * ((i - 19f) / 10f) + 3, 2f * Mathf.PI * (13f / 18f), new Vector3(pos.x, pos.y));
        }
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

        for (int i = 0; i <= 71; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(7f, 2f * Mathf.PI * ((i +1f) / 36f), new Vector3(pos.x, pos.y));
        }
    }

    public void Sun2(Vector3 pos)
    {
        GameObject[] magazine;
        magazine = FindBullets(54);

        for (int i = 0; i <= 35; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(6f, 2f * Mathf.PI * ((i + 1f) / 36f), new Vector3(pos.x, pos.y));
        }

        for (int i = 36; i <= 53; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(7f, 2f * Mathf.PI * ((i + 1f) / 18f), new Vector3(pos.x, pos.y));
        }
    }
}
