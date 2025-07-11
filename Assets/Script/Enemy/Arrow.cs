using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public EnemyShoot enemtyShoot;
    public GameObject blood;
    public GameObject bloodEffectPrefab; // Inspector'dan prefab atanacak
    public Transform bloodSpawnPoint;

    void Start()
    {
        bloodSpawnPoint = GameObject.FindGameObjectWithTag("PlayerBlood").transform;
        Debug.Log("BloodSpawnPoint" + bloodSpawnPoint.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyuncu VURULDU");

            enemtyShoot.hit(enemtyShoot.enemy.attackPower); // EnemyShoot'taki EnemyData'dan damage'ı aldım.
        

            Vector3 contactPoint = bloodSpawnPoint.position;
            Debug.Log("Contact point" + contactPoint);
            Quaternion rotation = Quaternion.LookRotation(bloodSpawnPoint.forward);

            blood = Instantiate(bloodEffectPrefab, contactPoint, rotation);
            Debug.Log("Blood point" + blood.transform.position);
            blood.transform.SetParent(bloodSpawnPoint); 


            Destroy(blood, 1);

            Destroy(gameObject); // mermiyi yok et
        }
        else if (!other.isTrigger)
        {
            Debug.Log("OK Başka bir şeye çarptı" + other);
            //Destroy(gameObject);
        }
    }
}
