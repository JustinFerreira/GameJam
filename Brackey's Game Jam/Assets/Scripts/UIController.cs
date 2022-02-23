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
    public TextMeshProUGUI healthLabel;
    public TextMeshProUGUI gameOverText;
    public Button playAgain;
    public TextMeshProUGUI rocksText;

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
        healthLabel.text = "Health: " + player.health;

        rocksText.text = "Rocks: " + player.rocks;

        if (player.health <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            
            if (gameOverText.alpha <= 100)
            {
                gameOverText.alpha += Time.deltaTime;
            }
            playAgain.gameObject.SetActive(true);

            
        }
    }

    private void HealthReader(int prevHealth)
    {
        if (player.health != prevHealth)
        {
            healthLabel.text = "Health: " + player.health;
        }
    }

    void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
