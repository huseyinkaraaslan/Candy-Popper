using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuScreen, scoreBoardScreen, gameScreen, endScreen;
    private bool inTheBeginning;

    void Start()
    {
        menuScreen.SetActive(true);
        scoreBoardScreen.SetActive(false);
        gameScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    private void Update()
    {
        if(gameObject.GetComponent<Timer>().time < 0)
        {
            gameScreen.SetActive(false);
            endScreen.SetActive(true);           
        }
    }

    public void playButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void scoreBoardButton()
    {
        scoreBoardScreen.SetActive(true);
        menuScreen.SetActive(false);        
    }

    public void backToMenu()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            scoreBoardScreen.SetActive(false);
            menuScreen.SetActive(true);
        }       
    }

    public void restartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
