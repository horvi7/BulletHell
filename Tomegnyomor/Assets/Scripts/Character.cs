using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public TimerScript timerScript;
    public GameObject greenHealth;
    private const float maxHealth = 100f;
    private float currentHealth = maxHealth;
    private bool isDead;


    float timer = 0;
    void Update()
    {
        setGreenHealthLength();
        healing();
    }

    private void healing()
    {
        timer += Time.deltaTime;
        if (timer >= 5 && currentHealth <= maxHealth - 2)
        {
            currentHealth += 2;
            timer = 0;
        }
        else if (timer >= 5 && currentHealth == maxHealth - 1)
        {
            currentHealth = maxHealth;
            timer = 0;
        }
    }

    public void makeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            Debug.Log("Character -hp: " + damage);
        }
        else if (currentHealth <= 0)
        {
            //GetComponent<CharacterGameOver>().GameOver();
            gameOver();
            isDead = true;
        }
    }
  
    private void setGreenHealthLength()
    {
        greenHealth.GetComponent<Image>().fillAmount = currentHealth / 100;
    }
    private void gameOver()
    {
        timerScript.GameOverPopup(false);
    }


}
