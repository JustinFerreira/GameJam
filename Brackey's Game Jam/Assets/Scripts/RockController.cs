using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float shotForce;
    private GameObject p;
    private PlayerController player;
    private GameObject x;
    private XRayController xRay;


    // Start is called before the first frame update
    void Start()
    {
        x = GameObject.FindGameObjectWithTag("XRay");
        xRay = x.GetComponent<XRayController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        p = GameObject.Find("Player");
        player = p.GetComponent<PlayerController>();
        shotForce = player.shotForce;
        rb.velocity = Vector2.up * shotForce;
        if (player.left)
        {
            rb.velocity = Vector2.left * (shotForce * 1.5f);
        }
        else
        {
            rb.velocity = Vector2.right * shotForce;
        }
        player.shotForce = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == p)
        {
            
        }
        else if (xRay.fakeObjects.Contains(collision.gameObject))
        {

        }
        else if (collision.gameObject.tag == "MushroomMan")
        {
            if (xRay.hiddenObjects.Contains(collision.gameObject))
            {
                xRay.hiddenObjects.Remove(collision.gameObject);
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        
    }
}
