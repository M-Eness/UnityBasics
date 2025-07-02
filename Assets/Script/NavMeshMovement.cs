using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
     private NavMeshAgent agent;
    private GameObject spawner;
    public float timer = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
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
                agent.SetDestination(hit.point);

            }
        }
    }
}
