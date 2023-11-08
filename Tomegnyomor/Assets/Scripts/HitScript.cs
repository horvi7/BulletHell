using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public HealthManagerScript healthManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //healthManager.gotHit(collision);
        //if (healthManager.currentHealth == 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //healthManager.continousDamage(collision);
        //if (healthManager.currentHealth == 0)
        //{
        //    Destroy(gameObject);
        //}
    }

}
