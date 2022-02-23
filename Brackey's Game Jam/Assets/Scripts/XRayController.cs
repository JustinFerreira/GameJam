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
    public Transform fakeParent;
    public Transform hiddenParent;

    // Start is called before the first frame update
    void Start()
    {
        foreach  (Transform t in fakeParent) // for every child of the Fake Objects empty in the scene
        {
            fakeObjects.Add(t.gameObject); // add to fake object list
        }
        foreach (Transform t in hiddenParent) // for every of the Hidden Objects empty in the scene
        {
            hiddenObjects.Add(t.gameObject); // add to hidden object list
        }
        playerBc = player.GetComponent<BoxCollider2D>(); 
        foreach (GameObject fake in fakeObjects) // for each fake object
        {
            bc = fake.GetComponent<BoxCollider2D>(); // get their box collider
            Physics2D.IgnoreCollision(bc, playerBc); // make it so they don't collide with the player
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // if press space
        {
            xrayActive = true; // x ray is active
            panel.gameObject.SetActive(true); // set screen tint active
            foreach (GameObject hiddenObject in hiddenObjects) // for each hidden object
            {
                spriteRenderer = hiddenObject.GetComponent<SpriteRenderer>(); // get hidden object's sprite renderer
                spriteRenderer.enabled = true; // set it true
            }
            foreach(GameObject fake in fakeObjects) // for each fake object
            {
                spriteRenderer = fake.GetComponent<SpriteRenderer>(); // get fake object's sprite renderer
                spriteRenderer.enabled = false; // set it false
                
            }
        }
        else // do the opposite of above
        {
            xrayActive = false; // x ray is not active
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
