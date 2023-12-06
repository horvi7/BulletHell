using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharatcer;
    [SerializeField] float speed;
    public float DamageBoost { get; set; } = 1.0f;
    [SerializeField] float damage = 1.0f;
    Rigidbody2D rgdbd2d;
    [SerializeField] float hp = 4.0f;
    int ghostDir = 1;


    private void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 directionToTarget = (targetDestination.position - transform.position).normalized;
        Vector3 forward = transform.forward;

        float dotProduct = Vector3.Dot(directionToTarget, transform.right);

        if (dotProduct > 0)
        { 
            transform.Rotate(Vector3.up, 180f); 
        }
    
      


        rgdbd2d.velocity = directionToTarget * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharatcer == null) 
        { 
            targetCharatcer = targetGameObject.GetComponent<Character>();
        }
        targetCharatcer.makeDamage(damage + DamageBoost);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Damage: " + damage);

        if (hp < 0)
        {
            Destroy(gameObject);
            if (targetCharatcer == null)
            {
                targetCharatcer = targetGameObject.GetComponent<Character>();
            }
            targetCharatcer.GetComponent<XPScript>().addXP(2);
        }
    }

}
