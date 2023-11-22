using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public int remainingTime = 5 * 5;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public GameObject restartButton;
    private float timer = 1f;


    // Start is called before the first frame update
    void Start()
    {
        timerText.text = GetTime();
        gameOverText.text = "";
        restartButton.SetActive(false);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            remainingTime--;
            timer = 1f;
        }

        // If remaining time is 0 or less game is won
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
