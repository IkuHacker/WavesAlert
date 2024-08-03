using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemieHealth : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Animator animator;
    public int currentHealth;
    public int maxHealth;

    [Space()]
    public int minCoinToGive;
    public int maxCoinToGive;
    public float healthChance = 0.1f;
    private EnemieFlip enemieFlip;// 10% chance to give health



    public void Start()
    {
        currentHealth = maxHealth;
        enemieFlip = gameObject.GetComponent<EnemieFlip>();
    }

    public void TakeDamge(int damage)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

    }

    public void Die()
    {
        int coinToGive = Random.Range(minCoinToGive, maxCoinToGive);
        switch (enemieFlip.playerToAttack) 
        {
            case "Player1":
                CoinManager.instance.AddCoin(coinToGive);
                break;
            case "Player2":
                CoinManagerPlayerTwo.instance.AddCoin(coinToGive);
                break;

        }
       
        if (Random.value < healthChance)
        {
            switch (enemieFlip.playerToAttack)
            {
                case "Player1":
                    CoinManager.instance.AddHealthPoint(2);
                    break;
                case "Player2":
                    CoinManagerPlayerTwo.instance.AddHealthPoint(2);
                    break;

            }
        }

        Destroy(objectToDestroy);
    }


}
