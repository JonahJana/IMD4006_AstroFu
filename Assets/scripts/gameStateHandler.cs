using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStateHandler : MonoBehaviour
{
    public GameObject startMenuPanel;
    public GameObject gamePlayPanel;
    public GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        startMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void showStartMenu()
    {
        startMenuPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void showGamePlay()
    {
        startMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void showGameOver()
    {
        startMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
