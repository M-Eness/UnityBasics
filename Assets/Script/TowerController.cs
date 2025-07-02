using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public TowerData towerData;
    public Transform barrel;
    public GameObject enemySpawner;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float bulletForce = 100f;
    public float fireCooldown = 0f;

    public Transform getClosestEnemy()
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform enemy in enemySpawner.transform)
        {
            float distance = Vector3.Distance(barrel.position, enemy.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
    public void Shoot()
    {
        Transform target = getClosestEnemy();
        GameObject bullet = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f); // istediğin ölçek
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        Vector3 direction = (target.position - barrel.position).normalized;
        rb.AddForce(direction * bulletForce, ForceMode.Impulse);
        fireCooldown = 1f / fireRate; // Her fireRate sürede bir atış
        Destroy(bullet, 2.0f); // 2 saniye sonra yok et
    }
    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
         Transform nearest = getClosestEnemy();
        if (nearest != null)
        {
            barrel.LookAt(nearest);
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0)
            {
                Shoot();
                fireCooldown = 1f / fireRate;
            }

        }
    }
}
