using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameObject;
    Character targetCharatcer;
    [SerializeField] float speed;
    

    Rigidbody2D rgdbd2d;

    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;
    //public void gotHit(Collision2D collision)
    //{
    //    //Shotgun egy példa. Ide kell kerülnie minden olyan dolognak, ami megsebezheti a karaktert.
    //    if (currentHealth > 0)
    //    {
    //        if (collision.gameObject.tag == Tag)
    //        {
    //            currentHealth -= 2;
    //            Debug.Log(Tag + " attacked");
    //        }
    //    }
    //    else Destroy(gameObject);
    //}

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

        targetCharatcer.makeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log(hp + " enemy hp");

        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
