using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public Character character;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        character.gotHit(collision);
        //if (character.currentHealth == 0)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        character.continousDamage(collision);
        //character.continousDamage(collision);
        //if (character.currentHealth == 0)
        //{
        //    Destroy(gameObject);
        //}
    }

}
