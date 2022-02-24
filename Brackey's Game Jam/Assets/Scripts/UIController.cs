using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private PlayerController player;
    public GameObject p;
    public TextMeshProUGUI gameOverText;
    public Button playAgain;

    //Heart gameObjects
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    //Rock gameObjects
    public TextMeshProUGUI rockNum;


    // Start is called before the first frame update
    void Start()
    {
        player = p.GetComponent<PlayerController>();
        gameOverText.gameObject.SetActive(false);
        gameOverText.alpha = 0;
        playAgain.onClick.AddListener(PlayAgain);
        playAgain.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.health <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            
            if (gameOverText.alpha <= 100)
            {
                gameOverText.alpha += Time.deltaTime;
            }
            playAgain.gameObject.SetActive(true);

            
        }

        if(player.health == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);

        }
        else if (player.health == 2)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);

        }
        else if (player.health == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);

        }
        else if (player.health == 0)
        {
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);

        }

        rockNum.text = "" + player.rocks;
    } 


    void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
