using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 5;
    public string bulletColor;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if ((bulletColor == "black" && enemy.enemyColor == "black") ||
                (bulletColor == "white" && enemy.enemyColor == "white"))
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        
        
    }
}
