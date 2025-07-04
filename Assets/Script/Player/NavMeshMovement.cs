using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject spawner;
    public float timer = 1f;
    public Animator anim; // animasyonları kontrol için

    bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        anim = GetComponent<Animator>();
       // test_spawner = spawner.GetComponent<SpawnEnemy>().tes;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timer;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                anim.SetBool("isWalking", true);
                agent.SetDestination(hit.point);
                isWalking = true;

            }

        }
         // Hedefe ulaşıldı mı kontrolü
    if (isWalking)
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude < 0.01f)
            {
                Debug.Log("HEDEFE ULAŞILDI");
                anim.SetBool("isWalking", false); // Idle animasyonu başlat
                isWalking = false; // Bir kereye mahsus çalışsın
            }
        }
    }
    }
}
