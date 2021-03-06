using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private GameObject player;
    private PlayerController pController;
    private GameObject xray;
    private XRayController x;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pController = player.GetComponent<PlayerController>();
        bc = this.gameObject.GetComponent<BoxCollider2D>();
        xray = GameObject.FindGameObjectWithTag("XRay");
        x = xray.GetComponent<XRayController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (x.fakeObjects.Contains(this.gameObject))
            {
                x.fakeObjects.Remove(this.gameObject);
            }
            if (x.hiddenObjects.Contains(this.gameObject))
            {
                x.hiddenObjects.Remove(this.gameObject);
            }
            if (this.gameObject.tag == "Rock")
            {
                pController.rocks += 1;
                SfxManager.SfxInstance.Audio.PlayOneShot(SfxManager.SfxInstance.PickUp);
                Destroy(this.gameObject);
            }
            else if (this.gameObject.tag == "Heart")
            {
                if (pController.health < 3)
                {
                    pController.health += 1;
                    SfxManager.SfxInstance.Audio.PlayOneShot(SfxManager.SfxInstance.PickUp);
                    Destroy(this.gameObject);
                }
                
            }
            else if (this.gameObject.tag == "Shroom")
            {
                if (x.xRayPower < 10)
                {
                    x.xRayPower += 3;
                    SfxManager.SfxInstance.Audio.PlayOneShot(SfxManager.SfxInstance.PickUp);
                    if (x.xRayPower > 10)
                    {
                        x.xRayPower = 10;
                    }
                    Destroy(this.gameObject);
                }
                
                
            }
            
        }
        
    }
}
