using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyShoot : MonoBehaviour
{
   public GameObject arrowPrefab;
    public Transform spawnPoint;
    public Transform player;
    public EnemyData enemy;
    public float arrowForce = 5f;
    public EnemyMovement enemyMovement;
    public TMP_Text player_health;
    void Start()
    {
        if (enemyMovement == null)
        {
            enemyMovement = GetComponent<EnemyMovement>();
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player_health == null)
        {
            player_health = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<TMP_Text>();
        }
        
        player_health.text = enemy.maxHealth.ToString();
    }

    public void Fire() // Atış animasyonunda tetiklenen fonksiyon
    {
        Debug.Log("Event Tetiklendi");
        if (!enemyMovement.isWalking)
        {
            Transform target = player.transform;

            if (target != null)
            {
                float upOffset = 1.5f;
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
        float health = float.Parse(player_health.text);
        Debug.Log("Karakter vuruludu");
        health -= damage;
        if (health <= 0)
        {
            player_health.text = "0";
            enemy.maxHealth = 0;
        }
        else
        {
            player_health.text = health.ToString();
            enemy.maxHealth = ((int)health);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
