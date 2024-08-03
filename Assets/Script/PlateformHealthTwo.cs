using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI
;


public class PlateformHealthTwo : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Text plateforHealthText;
    public int currentLevel;



    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        plateforHealthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        currentHealth = 0;
        Destroy(gameObject);

    }

    public void AddBonus(int lvl)
    {
        switch (lvl)
        {
            case 1:
                if(maxHealth == currentHealth) 
                {
                    maxHealth = 30;
                    maxHealth = currentHealth;
                }
                if (currentHealth >= maxHealth)
                {
                    maxHealth = currentHealth;
                }
                break;
            case 2:
                if (maxHealth == currentHealth)
                {
                    maxHealth = 60;
                    maxHealth = currentHealth;
                }

                currentHealth += 30;
                if (currentHealth >= maxHealth)
                {
                    maxHealth = currentHealth;
                }
                break;
            case 3:
                if (maxHealth == currentHealth)
                {
                    maxHealth = 75;
                    maxHealth = currentHealth;
                }

                currentHealth += 15;
                if (currentHealth >= maxHealth)
                {
                    maxHealth = currentHealth;
                }
                break;
                
        }

        currentLevel = lvl;
    }
}
