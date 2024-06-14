using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEnemy : Enemy
{
    private bool hasMoved = false;

    void Start()
    {
        
        speed = 2f;
        
        
        StartCoroutine(MoveRandomly());
    }

    void Update()
    {
        
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        
        if (Time.time > nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 3f;
        }
    }

    private IEnumerator MoveRandomly()
    {
        
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        if (!hasMoved)
        {
            
            float direction = Random.Range(0, 2) == 0 ? -1 : 1;
            float moveDistance = Random.Range(3f, 6f); 
            Vector3 targetPosition = transform.position + new Vector3(moveDistance * direction, 0, 0);

            
            float moveSpeed = 10f; 
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            hasMoved = true;
        }
    }



    private void Attack()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}
