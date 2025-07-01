using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gun;
    public GameObject player;
    public float bulletForce = 2000f;
    void Start()
    {
        
    }

    public void fire()
    {
        Transform target = player.transform.gameObject.GetComponent<ClosestEnemy>().getClosestEnemy();
        if (target != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, gun.position, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            Vector3 direction = (target.position - gun.position).normalized;
            rb.AddForce(direction * bulletForce, ForceMode.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
         {
             fire();
         }
    }
}
