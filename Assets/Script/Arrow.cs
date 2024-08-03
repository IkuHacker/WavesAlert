using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit;
    public Bow currentBow;
    public BowController currentBowController;
    void Start()
    {
        currentBow = GetBow.instance.currentBow;
        currentBowController = GetBow.instance.currentBowController;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasHit) 
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        if (collision.transform.CompareTag("Player1")) 
        {
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(currentBow.currentDamage);
        }else if (collision.transform.CompareTag("Player2")) 
        {
            collision.transform.GetComponent<PlayerHealth>().TakeDamage(currentBowController.currentDamage);
        }
        else if (collision.transform.CompareTag("Enemy")) 
        {
            collision.transform.GetComponent<EnemieHealth>().TakeDamge(currentBowController.currentDamage);
        }

            if (collision.transform.CompareTag("PlateformOne"))
        {
            collision.transform.GetComponent<PlateformHealthOne>().TakeDamage(currentBow.currentDamage);
        }
        else if (collision.transform.CompareTag("PlateformTwo"))
        {
            collision.transform.GetComponent<PlateformHealthTwo>().TakeDamage(currentBowController.currentDamage);
        }
    }
}
