using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject backToMenuPanel;
    public GameObject buttonBack;
    public GameObject tapToPlayPanel;
    public GameObject winPanel;
    public Text textCoins;
    public Text textSize;
    public Text textWonCoins;

    private void Start()
    {
        Time.timeScale = 0;
        textCoins.text = Game.coins.ToString();
    }

    public void ShowLosePanel()
    {
        buttonBack.SetActive(false);
        losePanel.SetActive(true);
    }

    public void OnButtonClickRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void OnButtonClickBackToMenu()
    {
        Time.timeScale = 0;
        backToMenuPanel.SetActive(true);
        buttonBack.SetActive(false);
    }

    public void OnButtonClickBackToMenuExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnButtonClickBackToMenuContinue()
    {
        backToMenuPanel.SetActive(false);
        buttonBack.SetActive(true);
        Time.timeScale = 1;
    }

    public void RefreshSizeUIText(float value)
    {
        textSize.text = System.Math.Round( value,2).ToString() + " m";
    }

    public void OnButtonClickStartToPlay()
    {
        Time.timeScale = 1;
        tapToPlayPanel.SetActive(false);
    }

    public void ShowWinPanel(int coins)
    {
        buttonBack.SetActive(false);
        winPanel.SetActive(true);
        textWonCoins.text = "+" + coins;
    }
}
