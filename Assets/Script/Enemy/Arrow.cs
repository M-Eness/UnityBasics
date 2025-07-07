using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public EnemyShoot enemtyShoot;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu VURULDU");

            enemtyShoot.hit(enemtyShoot.enemy.attackPower); // EnemyShoot'taki EnemyData'dan damage'ı aldım.

            Destroy(gameObject); // mermiyi yok et
        }
        else if (!other.isTrigger)
        {
            Debug.Log("OK Başka bir şeye çarptı" + other);
            //Destroy(gameObject);
        }
    }
}
