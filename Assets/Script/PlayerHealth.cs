using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Sprite emptyHeart;
    public Sprite heart;
    public Animator animator;
    public string winner;

    public List<Image> hearts = new List<Image>();
  
    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }



    public void UpdateUI()
    {

        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = heart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateUI();
    }

    public void Die()
    {
        GameOverManager.instance.GameOver(winner);
        animator.SetTrigger("Die");
        currentHealth = 0;
        Destroy(gameObject);

    }
}

