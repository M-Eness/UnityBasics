using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealthBar enemyHealth = other.GetComponent<EnemyHealthBar>();
            if (enemyHealth != null)
            {
                enemyHealth.takeDamage(25);
            }

            Destroy(gameObject); // mermiyi yok et
        }
    }
}
