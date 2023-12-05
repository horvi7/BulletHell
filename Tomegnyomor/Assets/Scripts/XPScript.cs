using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPScript : MonoBehaviour
{
    [SerializeField] MoveScript moveScript;
    [SerializeField] Enemy enemyScript;
    [SerializeField] int XP { get; set; } = 0;
    [SerializeField] float damageBoostFactor = 1.5f;

    public void addXP(int _xp)
    {
        XP += _xp;
        levelBasedChange();

    }
    private void levelBasedChange()
    {
        float speedBoostFactor = 0.05f;
     
        moveScript.speed += XP / 10 * speedBoostFactor;
      
    }
    public float GetDamageBoost()
    {
        return XP / 10 * damageBoostFactor;
    }
}
