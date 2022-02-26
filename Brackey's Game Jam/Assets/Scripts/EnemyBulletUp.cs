using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletUp : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    public float shotForce;
    private XRayController xray;
    private GameObject xrayObject;
    private int rand;
    private GameObject player;
    private BoxCollider2D playerBc;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerBc = player.GetComponent<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();
        xrayObject = GameObject.FindGameObjectWithTag("XRay");
        xray = xrayObject.GetComponent<XRayController>();
        shotForce = 5f;
        rb = GetComponent<Rigidbody2D>();
        rand = Random.Range(0, 3);
        if (rand == 0)
        {

        }
        else if (rand == 1)
        {
            xray.fakeObjects.Add(gameObject);
            Physics2D.IgnoreCollision(cc, playerBc);

        }
        else if (rand == 2)
        {
            xray.hiddenObjects.Add(gameObject);
            anim.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * shotForce;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();
            p.health -= 1;
            Destroy(gameObject);
        }
        else if (xray.fakeObjects.Contains(collision.gameObject))
        {
            //Dont destroy
        }
        else if (collision.gameObject.CompareTag("WallShroom") || collision.gameObject.CompareTag("MushroomMan"))
        {

        }
        else
        {
            if (rand == 1)
            {
                xray.fakeObjects.Remove(gameObject);
            }
            if (rand == 2)
            {
                xray.hiddenObjects.Remove(gameObject);
            }
            Destroy(gameObject);
        }

    }
}
