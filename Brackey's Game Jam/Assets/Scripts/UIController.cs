using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private PlayerController player;

    public Text healthLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //healthReader(player.health);
    }

    private void healthReader(int prevHealth)
    {
        if (player.health != prevHealth)
        {
            healthLabel.text = "Health: " + player.health;
        }
    }

}
