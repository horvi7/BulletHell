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
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
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
        //Debug.Log("Attacking the character");
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
