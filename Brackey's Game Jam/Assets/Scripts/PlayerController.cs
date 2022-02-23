using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Position Variable
    private float fHorizontal;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        xray = xrayObject.GetComponent<XRayController>();
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!xray.xrayActive)
        {
            rb.gravityScale = 1;
            fHorizontal = Input.GetAxis("Horizontal"); //Get Player Position for Horizontal

            rb.velocity = new Vector2(fHorizontal * speed, rb.velocity.y); //Player Movement Left and Right

            if (IsGrounded() && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }

        if(health == 0)
        {
            GameOver();
        }
       
    }

    private bool IsGrounded()
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
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + extraHeight), Vector2.right * (bc.bounds.extents.y * 2), rayColor);
        return raycastHit.collider != null;
    }

    private void GameOver()
    {
        Physics2D.IgnoreLayerCollision(7, 6);
    }
}
