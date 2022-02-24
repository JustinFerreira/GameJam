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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();

        if (player.transform.position.x >= xPatrolRangeMin - .5f && player.transform.position.x <= xPatrolRangeMax + .5f && player.transform.position.y <= this.transform.position.y + 0.91f)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rb.velocity = new Vector2(-1f, rb.velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rb.velocity = new Vector2(1f, rb.velocity.y);
            }
        }

        void Patrol()
        {
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
                if (transform.position.x > xPatrolRangeMin)
                {
                    rb.velocity = new Vector2(-1, rb.velocity.y);
                    anim.SetBool("walk", true);
                }
                else if (transform.position.x <= xPatrolRangeMin)
                {
                    moving = false;
                    anim.SetBool("walk", false);
                }
            }
            else if (moving && !left)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                if (transform.position.x < xPatrolRangeMax)
                {
                    rb.velocity = new Vector2(1, rb.velocity.y);
                    anim.SetBool("walk", true);
                }
                else if (transform.position.x >= xPatrolRangeMax)
                {
                    moving = false;
                    anim.SetBool("walk", false);
                }
            }
        }
    }
}
