using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image Foreground;
    public Transform HPCanvas;
    public float maxHealth = 100f;
    public float currentHealth;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        updateHealthBar();
        if (currentHealth <= 0)
        {
            BloodManager.KanSayacı.addBlood(20);
            anim.SetBool("isDead", true);
            Destroy(HPCanvas.parent.gameObject, 1.5f); // Düşmanı yok et
            
        }
        
    }

    public void updateHealthBar()
    {
        Debug.Log("healthFillImage: " + Foreground);
        float ratio = currentHealth / maxHealth;
        Foreground.fillAmount = ratio;
    }

    // Update is called once per frame
    void Update()
    {
        HPCanvas.LookAt(Camera.main.transform);
    }
}
