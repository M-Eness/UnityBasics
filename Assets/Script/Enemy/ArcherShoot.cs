using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
   public GameObject arrowPrefab;
    public Transform spawnPoint;
    public Transform player;
    public EnemyData enemy;
    public float arrowForce = 5f;
    public EnemyMovement enemyMovement;
    void Start()
    {
        if (enemyMovement == null)
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void FireArrow() // Atış animasyonunda tetiklenen fonksiyon
    {
        if (!enemyMovement.isWalking)
        {
            Transform target = player.transform;

            if (target != null)
            {
                float upOffset = 1.5f;
                Vector3 direction = ((target.position + Vector3.up * upOffset) - spawnPoint.position).normalized;
                GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.LookRotation(direction));

                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                rb.AddForce(direction * arrowForce, ForceMode.Impulse);
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
