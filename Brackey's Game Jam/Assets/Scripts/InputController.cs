using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public Button play;

    public Button help;

    public Button back;

    public GameObject mainScreen;

    public GameObject helpScreen;

    // Start is called before the first frame update
    void Start()
    {
        help.onClick.AddListener(Help);
        play.onClick.AddListener(Play);
        back.onClick.AddListener(Back);
        helpScreen.SetActive(false);
        mainScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Help()
    {
        mainScreen.SetActive(false);
        helpScreen.SetActive(true);
    }

    void Back()
    {
        mainScreen.SetActive(true);
        helpScreen.SetActive(false);
    }

    void Play()
    {
        SceneManager.LoadScene(1);
    }
}
