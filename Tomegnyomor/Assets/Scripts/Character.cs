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
    public GameObject greenHealth;
    private const float maxHealth = 100f;
    private float currentHealth = maxHealth;

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

    public void makeDamage(int damage)
    {
        //Shotgun egy példa. Ide kell kerülnie minden olyan dolognak, ami megsebezheti a karaktert.
        if (currentHealth > 0)
        {
                currentHealth -= damage;
        }
        else
        {
            gameOver();
        }
    }
    public void continousDamage(Collision2D collision)
    {
        if (currentHealth > 0)
        {
            //TODO: Pl tûzben áll akkor mennyit sebzõdjön. Eggyel feljebbi fv jó példa.
            //Kell bele valami idõzítés, különben élet lemegy pillanat alatt.
        }
    }
    private void setGreenHealthLength()
    {
        greenHealth.GetComponent<Image>().fillAmount = currentHealth / 100;
    }
    private void gameOver()
    {
        //Ha <0 hp akkor valami game over screen
    }


}
