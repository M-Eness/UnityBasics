using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 100;
    public float radius = 10f;
    public GameObject alanSkillEffectPrefab;
    public float fallSpeed = 10f;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Meteor yere çarptı!");

            if (alanSkillEffectPrefab != null)
            {
                Destroy(Instantiate(alanSkillEffectPrefab, transform.position, Quaternion.identity), 1f);
            }

            ApplyAreaDamage();

            Destroy(gameObject);
        }
    }
    void ApplyAreaDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, radius);
        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                EnemyHealthBar e = enemy.GetComponent<EnemyHealthBar>();
                if (e != null)
                {
                    e.takeDamage(damage);
                }
            }
        }
    }

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.down * fallSpeed;
    }

}
