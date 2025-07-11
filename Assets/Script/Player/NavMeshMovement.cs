using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject spawner;
    public float timer = 1f;
    public Animator anim; // animasyonları kontrol için

    bool isWalking = false;

    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject gameOverCanvas;
    public SkillManager skillManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        skillManager = GetComponent<SkillManager>();
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        anim = GetComponent<Animator>();
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOver");
        gameOverCanvas.SetActive(false);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timer;
        if (SkillManager.currentSkill == SkillManager.SkillType.none)
        {
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
        }
        else
        {
            Debug.Log("Skill Seçili olduğu için yürüyemezsin");
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

    public void TakeDamage(float amount)
    {
        if ((currentHealth - amount) > 0)
        {
            currentHealth -= amount;
        }else
            currentHealth = 0;
        
        if (currentHealth <= 0)
        {
            this.tag = "Dead";
            StartCoroutine(HandleDeath());
            



        }
    }
    
    private IEnumerator HandleDeath()
    {
        //Ölüm animasyonunu tetikle
        anim.SetBool("isDead", true);
        Debug.Log("Karakter öldü. Animasyon başladı.");

        float deathAnimationDuration = 2.0f;
        yield return new WaitForSeconds(deathAnimationDuration);

        Destroy(this.gameObject); // karakteri yok et 
        gameOverCanvas.SetActive(true); // Game Over ekranı
       
        
       
    }

}
