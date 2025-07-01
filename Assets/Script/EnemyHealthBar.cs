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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        updateHealthBar();
        if (currentHealth <= 0)
        {
            Destroy(HPCanvas.parent.gameObject); // Düşmanı yok et
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
