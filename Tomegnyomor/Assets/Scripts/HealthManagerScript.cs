//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Threading;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UI;

//public class HealthManagerScript : MonoBehaviour
//{
//    public GameObject greenHealth;
//    public float currentHealth = maxHealth;
//    private const float maxHealth = 100f;

//    float timer = 0;
//    void Update()
//    {
//        setGreenHealthLength();
//        healing();
//    }

//    private void healing()
//    {
//        timer += Time.deltaTime;
//        if (timer >= 5 && currentHealth <= maxHealth -2)
//        {
//            currentHealth += 2;
//            timer = 0;
//        }else if(timer >= 5 && currentHealth == maxHealth - 1)
//        {
//            currentHealth = maxHealth;
//            timer = 0;
//        }
//    }




//}
