using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Transform target;
    public float speed = 25f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Hedef atanmamışsa veya Rigidbody yoksa hata verip kendini yok et.
        
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - rb.position).normalized;
        rb.velocity = direction * speed;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
    }

    // Bir şeye çarptığında çalışır
   /* void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collisiona girildi");
        // Eğer çarptığımız nesne bizim hedefimizse...
        if (collision.transform == target)
        {
            Debug.Log(target.name + " vuruldu!");
            EnemyHealthBar e = collision.gameObject.GetComponent<EnemyHealthBar>();
            e.takeDamage(100);
            Destroy(gameObject);
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger'a girildi. Çarpan nesne: " + other.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(target.name + " vuruldu!");
            EnemyHealthBar e = other.GetComponent<EnemyHealthBar>();
            e.takeDamage(100);
            Destroy(gameObject);
        }
    }
}
