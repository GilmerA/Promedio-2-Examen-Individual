using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float velocity = 5f;
    public int health = 5;
    public GameObject blackBulletPrefab;
    public GameObject whiteBulletPrefab;
    public Transform firePoint;
    

    void Start()
    {
     
    }

    void Update()
    {
        Move();
        Shoot();
        
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * velocity * Time.deltaTime, Space.World);


        if (movement != Vector3.zero)
        {
            transform.forward = Vector3.forward;
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(blackBulletPrefab, firePoint.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(whiteBulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

