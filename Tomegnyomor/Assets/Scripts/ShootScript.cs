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
    public float BulletDamage { get; set; } = 2.0f;
    [SerializeField] float bulletSpeed;
    private float fireTimer;

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
        const float radToAngle = 57.3f;

        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - firingPoint.position;
        float rotationAngle = Mathf.Atan(shootDirection.x / shootDirection.y) * radToAngle;
        var bulletInstance = Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0,0, -rotationAngle)));
        bulletInstance.GetComponent<CollisionHandler>().Damage = BulletDamage;
        Vector2 velocity = new Vector2(shootDirection.x, shootDirection.y);
        velocity = velocity.normalized * bulletSpeed;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = velocity;
        Destroy(bulletInstance, bulletLifeTime);
    }

}
