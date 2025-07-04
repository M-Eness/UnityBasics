using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public EnemyData enemy;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Yön vektörü ve mesafe hesapla
        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (player != null)
        {
            if (enemy.enemyName == "Archer")
            {
                Debug.Log($"ARCHER MESAFE: {distance}, RANGE: {enemy.range}");
                if (distance > enemy.range)
                {
                    Debug.Log("MESAFE ÇOK UZAK");
                    // Okcunun range i kadar uzakta kalacak oradan saldıracak.
                    Vector3 targetPosition = player.position - direction.normalized * enemy.range;
                    agent.SetDestination(targetPosition);
                }
                else
                {
                    // Yeterince yakınsa dur
                    agent.ResetPath();
                }
            }
            else
            {
                agent.SetDestination(player.position);
            }
        }
    }
}
