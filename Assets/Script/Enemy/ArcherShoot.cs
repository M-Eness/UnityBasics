using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyShoot : MonoBehaviour
{
   public GameObject arrowPrefab;
    public Transform spawnPoint;
    public EnemyData enemy;
    public float arrowForce = 5f;
    public EnemyMovement enemyMovement;
    public TMP_Text player_health;
    public NavMeshMovement playerStats;
    public float currentHealth;
    void Start()
    {
        if (enemyMovement == null)
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }
        
        if (player_health == null)
        {
            player_health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<TMP_Text>();
        }

        if (playerStats == null)
            playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshMovement>();

        currentHealth = playerStats.currentHealth;
        player_health.text = currentHealth.ToString();
        Debug.Log("TEKRAR ÇALIŞTI");
    }

    public void Fire() // Atış animasyonunda tetiklenen fonksiyon
    {
        Debug.Log("Event Tetiklendi");
        if (!enemyMovement.isWalking)
        {
            Transform target = playerStats.transform;

            if (target != null && playerStats.gameObject.CompareTag("Player"))
            {
                float upOffset = 1.2f;
                Vector3 direction = ((target.position + Vector3.up * upOffset) - spawnPoint.position).normalized;
                GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.LookRotation(direction));
                arrow.GetComponent<Arrow>().enemtyShoot = this; 

                Rigidbody rb = arrow.GetComponent<Rigidbody>();
                rb.AddForce(direction * arrowForce, ForceMode.Impulse);
                Destroy(arrow, 3.0f);
                Debug.Log("OK FIRLATILDIIIIII");
            }
        }
    }
    

    public void hit(float damage)
    {
        
        Debug.Log("Karakter vuruludu");
        playerStats.TakeDamage(damage);

        player_health.text = playerStats.currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
