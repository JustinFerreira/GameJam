using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Position Variable
    private float fHorizontal;
    public bool left;
    public float shotForce;

    //Colliders
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    //Player Movement Speed
    public float speed;
    
    public float jumpForce;

    public float extraHeight;

    [SerializeField] private LayerMask platforms;

    public GameObject xrayObject;
    private XRayController xray;

    //Player Stats
    public int health;
    public int rocks;

    private Animator anim;

    public Transform slingshot;
    public GameObject rock;

    public bool hurt;
    public bool knockLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        xray = xrayObject.GetComponent<XRayController>();
        anim = gameObject.GetComponent<Animator>();
        health = 3;
        rocks = 3;
        shotForce = 5f;
        hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hurt)
        {
            health -= 1;
            anim.SetTrigger("hurt");
            if (knockLeft)
            {
                rb.AddForce(Vector2.left * 1000);
            }
            else
            {
                rb.AddForce(Vector2.right * 1000);
            }
            hurt = false;
        }
        if (!xray.xrayActive) // If X-Ray is not active
        {
            Time.timeScale = 1f; // Unfreeze time

            fHorizontal = Input.GetAxis("Horizontal"); // Get Player Position for Horizontal

            if (fHorizontal != 0) // if moving
            {
                anim.SetBool("walking", true); // start walking animation
            }
            else // if not moving
            {
                anim.SetBool("walking", false); // stop walking animation
            }
            if (fHorizontal < 0) // if moving left
            {
                left = true;
                this.gameObject.transform.localScale = new Vector2(-1, 1); // face player to left
            }
            else if (fHorizontal > 0) // if moving right
            {
                left = false;
                this.gameObject.transform.localScale = new Vector2(1, 1); // face player to right
            }

            rb.velocity = new Vector2(fHorizontal * speed, rb.velocity.y); // Move player in direction of input

            if (IsGrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) // If player is touching the ground and jumps
            {
                rb.velocity = Vector2.up * jumpForce; // Jump
            }

            if (rocks > 0 && Input.GetKey(KeyCode.C)) // if player has rocks and presses C
            {
                if (shotForce < 20)
                {
                    shotForce += (Time.deltaTime * 3); // increases shotforce while holding c
                }
                
            }

            if (rocks > 0 && Input.GetKeyUp(KeyCode.C)) // if player has rocks and presses C
            {
                anim.SetTrigger("shoot"); // shoot animation
                Instantiate(rock, slingshot);
                rocks -= 1; // lose 1 rock
            }

        }
        else // If X-Ray is active
        {
            Time.timeScale = 0f; // Freeze time
        }

        if(health == 0) // If dead
        {
            GameOver(); 
        }
       
    }

    private bool IsGrounded() // Function to test if player is touching the ground
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, platforms);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeight), Vector2.right * (bc.bounds.extents.x * 2), rayColor);
        return raycastHit.collider != null;
    }

    private void GameOver()
    {
        //Physics2D.IgnoreLayerCollision(7, 6); // Player ignores terrain collisions, falls off map
        Destroy(bc);
    }
}
