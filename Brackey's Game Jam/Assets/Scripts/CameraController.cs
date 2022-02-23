using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 lastPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Being Pinned to Character
        gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
