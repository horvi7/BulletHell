using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player") && gameObject.tag == "SpeedBoost")
        {
            PickUpSpeedBoost(player);
        }else if(player.CompareTag("Player") && gameObject.tag == "DamageBoost")
        {
            PickUpDamageBoost(player);
        }
    }

    void PickUpSpeedBoost(Collider2D player)
    {
        MoveScript moveScript = player.gameObject.GetComponent<MoveScript>();

        if (moveScript != null)
        {
            moveScript.speed += 0.5f;
        }
        Destroy(gameObject);
    }

    void PickUpDamageBoost(Collider2D player)
    {
  
        Debug.Log("Felvette");
        player.GetComponent<ShootScript>().BulletDamage *= 2; 
    
        Destroy(gameObject);
    }

}
