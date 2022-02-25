using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomManController : MonoBehaviour
{
    public float xPatrolRangeMin;
    public float xPatrolRangeMax;
    bool left;
    bool moving;

    private Rigidbody2D rb;
    private Animator anim;

    private GameObject player;

    private GameObject x;
    private XRayController xRay;

    private float attackRange = .4f;
    [SerializeField] public LayerMask playerLayer;
    private Collider2D[] hits;

    private bool facingLeft;
    private PlayerController p;
    private bool ready;
    private float t;
    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        x = GameObject.FindGameObjectWithTag("XRay");
        xRay = x.GetComponent<XRayController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        p = player.GetComponent<PlayerController>();
        anim.SetBool("walk", true);
        ready = true;
        facingLeft = true;
        t = 2f;
    }

    // Update is called once per frame
    void Update()
    {   
        if (!xRay.fakeObjects.Contains(gameObject))
        {
            if (dead)
            {
                Destroy(GetComponent<BoxCollider2D>());
            }
            else
            {
                if (!ready)
                {
                    if (t > 0)
                    {
                        t -= Time.unscaledDeltaTime;
                    }
                    if (t <= 0)
                    {
                        ready = true;
                        t = 2f;
                    }
                }
                if (facingLeft && ready)
                {
                    hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(-0.428f, .15f, 0), attackRange, playerLayer);
                }
                else if (!facingLeft && ready)
                {
                    hits = Physics2D.OverlapCircleAll(transform.position + new Vector3(0.428f, .15f, 0), attackRange, playerLayer);
                }
                if (ready)
                {
                    foreach (Collider2D hit in hits)
                    {
                        ready = false;
                        p.hurt = true;
                        if (facingLeft)
                        {
                            p.knockLeft = true;
                        }
                        else
                        {
                            p.knockLeft = false;
                        }

                    }
                }
            }
            
        }
        
        

        if (xRay.fakeObjects.Contains(gameObject))
        {
            Patrol();
        }
        else if ((player.transform.position.x >= xPatrolRangeMin - .5f && player.transform.position.x <= xPatrolRangeMax + .5f && player.transform.position.y <= transform.position.y + 0.91f)
            || (player.transform.position.x >= transform.position.x - 2f && player.transform.position.x <= transform.position.x + 2f &&
            player.transform.position.y <= transform.position.y + 2f && player.transform.position.y >= transform.position.y))
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                facingLeft = true;
                rb.velocity = new Vector2(-1f, rb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                facingLeft = false;
                rb.velocity = new Vector2(1f, rb.velocity.y);
            }
        }
        else
        {
            Patrol();
        }

        void Patrol()
        {
            if (transform.position.x < xPatrolRangeMin)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                facingLeft = false;
                rb.velocity = new Vector2(1f, rb.velocity.y);
            }
            if (transform.position.x > xPatrolRangeMax)
            {
                transform.localScale = new Vector3(1, 1, 1);
                facingLeft = true;
                rb.velocity = new Vector2(-1f, rb.velocity.y);
            }
            if (transform.position.x >= xPatrolRangeMin - 1 && transform.position.x < xPatrolRangeMin + 1 && !moving)
            {
                left = false;
                moving = true;
            }
            if (transform.position.x <= xPatrolRangeMax + 1 && transform.position.x > xPatrolRangeMax - 1 && !moving)
            {
                left = true;
                moving = true;
            }
            if (moving && left)
            {
                transform.localScale = new Vector3(1, 1, 1);
                facingLeft = true;
                if (transform.position.x > xPatrolRangeMin)
                {
                    rb.velocity = new Vector2(-1, rb.velocity.y);
                }
                else if (transform.position.x <= xPatrolRangeMin)
                {
                    moving = false;
                }
            }
            else if (moving && !left)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                facingLeft = false;
                if (transform.position.x < xPatrolRangeMax)
                {
                    rb.velocity = new Vector2(1, rb.velocity.y);
                }
                else if (transform.position.x >= xPatrolRangeMax)
                {
                    moving = false;
                }
            }
        }
    }
    //IEnumerator AttackTimer()
    //{
    //    float t = 3;
    //    while (t > 0)
    //    {
    //        t -= Time.unscaledDeltaTime;
    //    }
    //    ready = true;
    //}
}
