using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Vector3 attackOffset;
    public LayerMask attackMask;
    public int attackDamage;

    public float attackWidth; // Largeur du rectangle
    public float attackHeight; // Hauteur du rectangle

    public void Attack() 
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapBox(pos, new Vector2(attackWidth, attackHeight), 0, attackMask);
        
        if(colInfo != null) 
        {
            if (colInfo.CompareTag("Player1") || colInfo.CompareTag("Player2"))
            {
                colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);

            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireCube(pos, new Vector3(attackWidth, attackHeight, 1));
    }


}
