using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float Damage { get; set; } = 2.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy e = collision.gameObject.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
