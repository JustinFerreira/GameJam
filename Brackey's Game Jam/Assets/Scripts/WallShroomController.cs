using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShroomController : MonoBehaviour
{
    public float waitTime;

    private float originalWaitTime;

    public GameObject bullet;

    private Transform attackPoint;
    private Transform thisShroom;

    private bool ready;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ready = true;
        thisShroom = GetComponent<Transform>();
        originalWaitTime = waitTime;
        foreach(Transform t in thisShroom)
        {
            attackPoint = t;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            Shoot();
            ready = false;
        }
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        if (waitTime <= 0)
        {
            ready = true;
            waitTime = originalWaitTime;
        }
        
    }

    void Shoot()
    {
        Debug.Log("Shoot");
        anim.SetTrigger("shoot");
        Instantiate(bullet, attackPoint);
    }
}
