using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
     private NavMeshAgent agent;
    private GameObject spawner;
    private GameObject[] test_spawner;
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);

            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (spawner.transform.childCount != 0)
            {
                spawner.transform.GetChild(0).gameObject.GetComponent<EnemyHealthBar>().takeDamage(10);
                if (spawner.transform.GetChild(0).gameObject.GetComponent<EnemyHealthBar>().currentHealth == 0)
                {
                    Destroy(spawner.transform.GetChild(0).gameObject);
                }

                }
        }
    }
}
