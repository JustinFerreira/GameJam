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

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fHorizontal = Input.GetAxis("Horizontal"); //Get Player Position for Horizontal
     
        rb.velocity = new Vector2(fHorizontal * speed, rb.velocity.y); //Player Movement Left and Right

        //Player Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
