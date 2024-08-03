using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Attack : MonoBehaviour
{
    public Animator animator;
    public bool canAttack;
    public bool isAttacking;
    public float attckColdown;
    public Transform attackPoint;
    public float attackRange;
    public int attackDamage;

    public int currentLevel;
    public Text lvlText;

    public LayerMask enemyLayer;

    void Update()
    {
        

        if (Input.GetMouseButtonDown(1))
        {
            
            StartCoroutine(PlayerAttack());
        }
    }
    private IEnumerator PlayerAttack() 
    {
        canAttack = false;
        isAttacking = true;
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (!enemy.isTrigger)
            {
                enemy.gameObject.GetComponent<EnemieHealth>().TakeDamge(attackDamage);
            }

        }

        yield return new WaitForSeconds(attckColdown);
        isAttacking = false;
        // Autoriser � nouveau l'attaque
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // Dessiner une sph�re visuelle pour repr�senter la port�e de l'attaque
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AddBonus(int lvl)
    {
        switch (lvl)
        {
            case 1:
                attackDamage = 3;
                break;
            case 2:
                attackDamage = 5;
                break;
            case 3:
                attackDamage = 7;
                break;
            default:
                attackDamage = 3;
                break;
        }
        currentLevel = lvl;
    }

    


}
