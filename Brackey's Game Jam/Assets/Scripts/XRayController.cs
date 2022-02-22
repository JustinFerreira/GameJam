using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayController : MonoBehaviour
{
    public GameObject panel;
    public bool xrayActive;
    public List<GameObject> hiddenObjects;
    public List<GameObject> fakeObjects;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D bc;
    public GameObject player;
    private BoxCollider2D playerBc;

    // Start is called before the first frame update
    void Start()
    {
        playerBc = player.GetComponent<BoxCollider2D>();
        foreach (GameObject fake in fakeObjects)
        {
            bc = fake.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(bc, playerBc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            xrayActive = true;
            panel.gameObject.SetActive(true);
            foreach (GameObject hiddenObject in hiddenObjects)
            {
                spriteRenderer = hiddenObject.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
            }
            foreach(GameObject fake in fakeObjects)
            {
                spriteRenderer = fake.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
                
            }
        }
        else
        {
            xrayActive = false;
            panel.gameObject.SetActive(false);
            foreach (GameObject hiddenObject in hiddenObjects)
            {
                spriteRenderer = hiddenObject.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = false;
            }
            foreach (GameObject fake in fakeObjects)
            {
                spriteRenderer = fake.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
            }
        }
    }
}
