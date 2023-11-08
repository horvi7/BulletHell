using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class ShootScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firingPoint;
    [SerializeField] float bulletLifeTime = 3f;
    [SerializeField] float shootingRate = 0.5f;
    [SerializeField] float bulletSpeed;
    private float fireTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
        if(Input.GetMouseButton(0) && fireTimer >= shootingRate)
        {
            shoot();
            fireTimer = 0;
        }
    }
    private void shoot()
    {
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - firingPoint.position;
        var bulletInstance = Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0, 0, -90)));
        var normalizedVec2 = shootDirection.normalized;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * bulletSpeed, shootDirection.y * bulletSpeed);
        Destroy(bulletInstance, bulletLifeTime);
    }
}
