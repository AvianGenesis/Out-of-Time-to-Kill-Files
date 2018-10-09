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
    private int fire2Tick;
    private int fire2Dur;

    private Vector3 resetPosition;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject absorbBeam;
    private GameObject slowDownAOE1, slowDownAOE2;
    private Camera cam;
    private Vector3 point = new Vector3();

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

        GameObject sDAOEPref = Resources.Load<GameObject>("Prefabs/SlowDownAOE");
        slowDownAOE1 = Instantiate<GameObject>(sDAOEPref);
        slowDownAOE2 = Instantiate<GameObject>(sDAOEPref);
        slowDownAOE1.SetActive(false);
        slowDownAOE2.SetActive(false);

        cam = Camera.main;
    }

    private void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.EndArea();
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
            if (invulTick == 120)
            {
                invul = false;
                invulTick = 0;
            }
        }

        //State checking
        if (fire1 == 1 && fire2 == 0)
        {
            //fire1
            anim.SetInteger("State", 1);
            absorbBeam.SetActive(true);
            absorbBeam.transform.position = new Vector2(transform.position.x + 8.837f, transform.position.y);
        }
        else if (fire1 == 0 && fire2 == 1)
        {
            absorbBeam.SetActive(false);
            //fire2
            anim.SetInteger("State", 2);
            fire2Tick++;
            if (fire2Tick == 60)
            {
                slowDownAOE1.SetActive(true);
                slowDownAOE1.transform.position = new Vector2(point.x, point.y);
                fire2Tick = 0;
                fire2Dur = 300;
            }
        }
        else
        {
            anim.SetInteger("State", 0);
            absorbBeam.transform.position = new Vector2(100f, 100f);
            //absorbBeam.SetActive(false);
            fire2Tick = 0;
        }

        //while SlowDown is active
        if (slowDownAOE1.activeInHierarchy)
        {
            fire2Dur--;
            if (fire2Dur == 0)
            {
                slowDownAOE1.transform.position = new Vector2(100f, 100f);
                //slowDownAOE1.SetActive(false);
            }
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
