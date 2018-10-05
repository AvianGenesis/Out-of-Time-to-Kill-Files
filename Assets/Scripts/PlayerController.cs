using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float health;
    public float flow;
    public float speed;
    public float velX;
    public float velY;
    public float score;
    public float energy;
    private int invulTick;
    private bool invul;

    private Vector3 resetPosition;
    private Rigidbody2D rb;
    private Rigidbody2D absBeamRB;
    private Animator anim;
    private GameObject absorbBeam;

    // Use this for initialization
    void Start()
    {
        health = 5f;
        flow = 1f;
        speed = 7f;
        invul = false;

        resetPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject absBeamPref = Resources.Load<GameObject>("Prefabs/AbsorbBeam");
        absorbBeam = Instantiate<GameObject>(absBeamPref);
        absorbBeam.SetActive(false);
        absBeamRB = absorbBeam.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float fire1 = Input.GetAxis("Fire1");
        float fire2 = Input.GetAxis("Fire2");
        velX = inputX * speed * flow;
        velY = inputY * speed * flow;

        rb.velocity = new Vector2(velX, velY);

        if (invul)
        {
            invulTick++;
            if(invulTick == 120)
            {
                invul = false;
                invulTick = 0;
            }
        }

        if (fire1 == 1 && fire2 == 0)
        {
            //fire1
            anim.SetInteger("State", 1);
            absorbBeam.SetActive(true);
            absorbBeam.transform.position = new Vector2(transform.position.x + 8.837f, transform.position.y);
        }
        else if (fire1 == 0 && fire2 == 1)
        {
            //fire2
            anim.SetInteger("State", 2);
        }
        else
        {
            anim.SetInteger("State", 0);
            absorbBeam.SetActive(false);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == LayerMask.NameToLayer("Damage") || collision.gameObject.layer == LayerMask.NameToLayer("Boss")) && !invul)
        {
            health--;
            transform.position = resetPosition;
            invul = true;
        }
    }
}
