using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{
    public EnemyShoot enemyShoot;
    public GameObject bloodEffectPrefab;
    public Transform bloodSpawnPoint;

    private bool hasHit = false; // Bir kez vurduktan sonra tekrar vurmasın


    void Start()
        {
            bloodSpawnPoint = GameObject.FindGameObjectWithTag("PlayerBlood").transform;
            
        }
    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return; // Zaten vurduysa çık
        if (other.CompareTag("Player"))
        {
            Debug.Log("Kılıç Oyuncuya Çarptı");

            enemyShoot.hit(enemyShoot.enemy.attackPower); // EnemyShoot'taki EnemyData'dan damage'ı aldım.

            // Kan efekti
            if (bloodEffectPrefab != null)
            {
                Vector3 contactPoint = bloodSpawnPoint.position;
                Quaternion rotation = Quaternion.LookRotation(bloodSpawnPoint.forward);

                GameObject blood = Instantiate(bloodEffectPrefab, contactPoint, rotation);
                blood.transform.SetParent(bloodSpawnPoint);
                Destroy(blood, 1f);
            }

            hasHit = true; // artık tekrar vurmasın
        }
    }

    public void ResetHit()
    { // Animasyona event olarak eklenebilir şimdilik kalsın.
        hasHit = false;
    }
}
