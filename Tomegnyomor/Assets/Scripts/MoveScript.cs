using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;


public class MoveScript : MonoBehaviour
{
    public float speed = 3;
    public GameObject healthBar;
    public Rigidbody2D rigidBody;
    public Animator animator;

    float walkTriggerTimer;
    Vector3 movementVector;
    Transform healthBarPosition;

    float turnTimer = 0;
    
    void Start()
    {
        walkTriggerTimer = 0;
        healthBarPosition = GetComponent<Transform>();
    }

    void Update()
    {
        walkTriggerTimer += Time.deltaTime;
        moveCharacter();
        moveHealthBar();
        turnCharacter();
        turnTimer = turnTimer + Time.deltaTime;
    }

    private void turnCharacter()
    {
            var scale = transform.localScale;
             float flip;
            if (gameObject.transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                flip = 0.75f;
            }
            else
            {
                flip = -0.75f;
            }
            gameObject.transform.localScale = new Vector3(flip, scale.y, scale.z);
            turnTimer = 0;
    }

    void moveCharacter()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        movementVector *= speed;
        rigidBody.velocity = movementVector;
        if (movementVector != new Vector3(0, 0, 0) && walkTriggerTimer >= 0.75)
        {
            playWalkAnimation();
            walkTriggerTimer = 0;
        }
        else playIdleAniamtion();   
    }
    private void playWalkAnimation()
    {
        animator.SetTrigger("Walking");
    }
    private void playIdleAniamtion()
    {
        animator.SetTrigger("Standing");
        
    }
    void moveHealthBar()
    {
        healthBarPosition.position = rigidBody.position;
    }
}
