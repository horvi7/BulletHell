using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player") && gameObject.tag == "SpeedBoost")
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
            moveScript.speed += 0.5f;
        }

        Destroy(gameObject);
    }
}
