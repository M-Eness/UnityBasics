using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gun;
    public GameObject player;
    public float bulletForce = 100f;
    public float fireRate = 2f; // saniyede 2 mermi
    private float fireCooldown = 0f;
    void Start()
    {
        
    }

    public void fire()
    {
        Transform target = player.transform.gameObject.GetComponent<ClosestEnemy>().getClosestEnemy();


        if (target != null && fireCooldown <= 0f)
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            Vector3 direction = (target.position - gun.position).normalized;
            rb.AddForce(direction * bulletForce, ForceMode.Impulse);
            fireCooldown = 1f / fireRate; // Her fireRate sürede bir atış
            Destroy(bullet, 2.0f); // 2 saniye sonra yok et
        }

    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        fire();
    }
}
