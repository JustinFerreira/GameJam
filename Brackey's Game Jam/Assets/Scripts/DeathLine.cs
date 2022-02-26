using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    private PlayerController player;
    private XRayController xray;
    private GameObject xrayObject;
    // Start is called before the first frame update
    void Start()
    {
        xrayObject = GameObject.FindGameObjectWithTag("XRay");
        xray = xrayObject.GetComponent<XRayController>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            player.health = 0;
        }
        else
        {
            if (xray.fakeObjects.Contains(collision.gameObject))
            {
                xray.fakeObjects.Remove(collision.gameObject);
            }
            else if (xray.hiddenObjects.Contains(collision.gameObject))
            {
                xray.hiddenObjects.Remove(collision.gameObject);
            }
            Destroy(collision.gameObject);
        }

    }
}
