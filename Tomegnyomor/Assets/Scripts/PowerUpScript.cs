using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            PickUp(player);
        }
    }

    void PickUp(Collider2D player)
    {
        // get player
        MoveScript moveScript = player.gameObject.GetComponent<MoveScript>();

        if (moveScript != null)
        {
            moveScript.speed += 3f;
        }

        Destroy(gameObject);
    }
}
