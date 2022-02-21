using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayVision : MonoBehaviour
{
    public GameObject panel;
    public bool xrayActive;
    public List<GameObject> hiddenObjects;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
