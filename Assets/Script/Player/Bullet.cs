using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject blood;
    public GameObject bloodEffectPrefab; // Inspector'dan prefab atanacak
    public Transform bloodSpawnPoint;


    void Start()
    {
         bloodSpawnPoint = GameObject.FindGameObjectWithTag("BloodPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
   void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("DÜŞMAN VURULDU");
            EnemyHealthBar enemyHealth = other.GetComponent<EnemyHealthBar>();
            if (enemyHealth != null && bloodSpawnPoint != null)
            {

                Vector3 contactPoint = bloodSpawnPoint.position;
                Vector3 directionToBullet = (transform.position - contactPoint).normalized;
                Quaternion rotation = Quaternion.LookRotation(directionToBullet);

                blood = Instantiate(bloodEffectPrefab, contactPoint, rotation);
                blood.transform.SetParent(bloodSpawnPoint); 

                enemyHealth.takeDamage(25);
                Destroy(blood, 1);
            }

            Destroy(gameObject); // mermiyi yok et
        }
    }
}
