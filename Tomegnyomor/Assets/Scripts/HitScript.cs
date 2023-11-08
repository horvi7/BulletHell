using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    public Character character;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        character.gotHit(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        character.continousDamage(collision);
    }

}
