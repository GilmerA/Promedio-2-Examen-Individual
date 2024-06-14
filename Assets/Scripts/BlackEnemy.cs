using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEnemy : Enemy
{
    void Start()
    {
        
        speed = 2f;
        nextAttackTime = Time.time + 1f;
    }

    void Update()
    {
        
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        
        if (Time.time > nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 5f;
        }

        
        float moveDirection = Mathf.Sin(Time.time * speed) * 5f;
        transform.Translate(Vector3.right * moveDirection * Time.deltaTime);
    }

    private void Attack()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
