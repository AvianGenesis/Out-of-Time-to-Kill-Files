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

    public void Shotgun1(Vector3 pos) //All 3 bursts at once in a spread
    {
        int bulletCount = 12;
        int indent = bulletCount / 3;
        //Vector3 target = GameObject.Find("Player").transform.position;
        GameObject[] magazine;
        magazine = FindBullets(bulletCount);

        for (int i = 0; i <= ((bulletCount / 3f) - 1); i++)
        {
            magazine[i + 0 * indent].GetComponent<BulletController>().DrawBullet(5.5f,
                                                                                 2f * Mathf.PI * (((2f * i + 1f) / (36f * (float)indent)) + (13f / 18f)),
                                                                                 new Vector3(pos.x, pos.y));
        }

        for (int i = 0; i <= ((bulletCount / 3f) - 1); i++)
        {
            magazine[i + 1 * indent].GetComponent<BulletController>().DrawBullet(4.5f,
                                                                                 2f * Mathf.PI * (((2f * i + 1f) / (36f * (float)indent)) + (13f / 18f)),
                                                                                 new Vector3(pos.x, pos.y));
        }

        for (int i = 0; i <= ((bulletCount / 3f) - 1); i++)
        {
            magazine[i + 2 * indent].GetComponent<BulletController>().DrawBullet(3.5f,
                                                                                 2f * Mathf.PI * (((2f * i + 1f) / (36f * (float)indent)) + (13f / 18f)),
                                                                                 new Vector3(pos.x, pos.y));
        }
        //put 30 bullets into array
        //iterate 10 at a time, 3 times
        //each 10 have same trajectory but different speeds
        //aimed directly to the left
    }

    public void Swirl1(Vector3 pos)
    {
        GameObject[] magazine;
        magazine = FindBullets(36);

        for(int i = 0; i <= 35; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(6f, Mathf.PI * ((i + 1f) / 36f) + Mathf.PI, new Vector3(pos.x, pos.y));
        }
    }

    public void Sun1(Vector3 pos)
    {
        GameObject[] magazine;
        magazine = FindBullets(36);

        for (int i = 0; i <= 35; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(3f, 2f * Mathf.PI * ((i +1f) / 36f), new Vector3(pos.x, pos.y));
        }
    }

    public void Sun2(Vector3 pos)
    {
        GameObject[] magazine;
        magazine = FindBullets(54);

        for (int i = 0; i <= 35; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(5f, 2f * Mathf.PI * ((i + 1f) / 36f), new Vector3(pos.x, pos.y));
        }

        for (int i = 36; i <= 53; i++)
        {
            magazine[i].GetComponent<BulletController>().DrawBullet(6f, 2f * Mathf.PI * ((i + 1f) / 18f), new Vector3(pos.x, pos.y));
        }
    }
}
