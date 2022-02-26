using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletRight : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    public float shotForce;
    // Start is called before the first frame update
    void Start()
    {
        shotForce = 5f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * shotForce;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();
            p.health -= 1;
            Destroy(gameObject);
        }
    }
}
