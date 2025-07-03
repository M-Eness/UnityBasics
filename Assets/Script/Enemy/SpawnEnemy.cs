using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;          // Spawn edilecek düşman prefabı
    public GameObject enemyArray;
    public Transform player;
    public Transform plane;
    public float minDistance = 5.0f;         // Oyuncudan ne kadar uzaklıkta spawn olacak
    public float spawnInterval = 5.0f;        // Kaç saniyede bir spawn edilecek
    private float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            spawn();
            timer = 0;
        }
    }

    void spawn()
    {
        // Rastgele bir yön belirle
        Vector3 spawnPoint;
        float distance;

        // Oyuncudan belli uzaklıkta bir pozisyon oluştur
        Vector3 planeSize = plane.GetComponent<MeshRenderer>().bounds.size;
        Vector3 planeCenter = plane.position;

        int maxAttempts = 100;
        int attempts = 0;

        do
        {
            float x = Random.Range(-planeSize.x / 2f, planeSize.x / 2f);
            float z = Random.Range(-planeSize.z / 2f, planeSize.z / 2f);
            spawnPoint = planeCenter + new Vector3(x, 0.5f, z);
            distance = Vector3.Distance(spawnPoint, player.position);
            attempts++;
        }
        while (distance <= minDistance && attempts < maxAttempts);

        if (attempts < maxAttempts)
        {
            GameObject newSpawnEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            newSpawnEnemy.transform.parent = this.transform;
        }
        else
        {
            Debug.LogWarning("Geçerli spawn noktası bulunamadı.");
        }
    }
         void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<EnemyHealthBar>().takeDamage(25);  // Mermi hasarını buradan ayarlayabilirsin
            Destroy(collision.gameObject); // Mermiyi yok et
        }
    }
}
