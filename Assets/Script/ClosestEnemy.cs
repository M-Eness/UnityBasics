using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestEnemy : MonoBehaviour
{
    public Transform player;
    public Transform enemySpawner;

    public Transform getClosestEnemy()
    {
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform enemy in enemySpawner)
        {
            float distance = Vector3.Distance(player.position, enemy.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform nearest = getClosestEnemy();
        if (nearest != null)
        {
            player.LookAt(nearest);
        }
    }
}
