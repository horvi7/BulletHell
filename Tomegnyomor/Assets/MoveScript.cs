using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class MoveScript : MonoBehaviour
{
    public float speed = 5;
    public GameObject healthBar;
    public Rigidbody2D rigidBody;
    public Animation walkAnimation;
    Vector3 movementVector;
    Transform healthBarPosition;
    float walkAnimationTimer;
    void Start()
    {
        healthBarPosition = GetComponent<Transform>();
    }

    void Update()
    {
        walkAnimationTimer += Time.deltaTime;
        playAnimation();
        moveCharacter();
        moveHealthBar();
    }

    private void playAnimation()
    {
        if(walkAnimationTimer >= 2)
        {
            walkAnimation.Play();
            walkAnimationTimer = 0;
        }
    }

    void moveCharacter()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.y = Input.GetAxis("Vertical");
        movementVector *= speed;
        rigidBody.velocity = movementVector;
        if (movementVector != new Vector3(0, 0, 0)) playAnimation();
        playAnimation();

    }
    void moveHealthBar()
    {
        healthBarPosition.position = rigidBody.position;
    }
}
