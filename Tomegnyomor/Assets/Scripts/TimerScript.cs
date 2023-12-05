using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] int remainingTime = 5 * 5;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject restartButton;
    private float timer = 1f;
    void Start()
    {
        timerText.text = GetTime();
        gameOverText.text = "";
        restartButton.SetActive(false);

        Time.timeScale = 1f;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            remainingTime--;
            timer = 1f;
        }

        if (remainingTime <= 0)
        {
            GameOverPopup(true);
        }

        // update text
        timerText.text = GetTime();
    }

    private string GetTime()
    {
        int minutes = remainingTime / 60;
        int seconds = remainingTime % 60;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOverPopup(bool win)
    {
        if (win)
        {
            gameOverText.text = "You WIN!";
        }
        else
        {
            gameOverText.text = "You LOSE!";
        }
        restartButton.SetActive(true);
        Time.timeScale = 0f;
    }
}
