using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public EnemyData enemy;
    public Animator anim;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public bool isWalking = true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.gameObject.CompareTag("Player"))
        {
            // Yön vektörü ve mesafe hesapla
            Vector3 direction = player.position - transform.position;
            float distance = direction.magnitude;

        
            if (enemy.enemyName == "Archer")
            {
                
                if (distance > enemy.range)
                {
                 
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
            // Hareket kontrolü ve animasyon
            // Agent velocity büyükse hareket ediyor, küçükse duruyor
            if (agent.velocity.sqrMagnitude > 0.1f)
            {
                if (!isWalking)
                {
                    anim.SetBool("isWalking", true);
                    isWalking = true;
                }
            }
            else
            {
                if (isWalking)
                {
                    anim.SetBool("isWalking", false);
                    isWalking = false;
                }
            }
        }
    } 
}
