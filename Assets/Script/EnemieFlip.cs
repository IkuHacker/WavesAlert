using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieFlip : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public bool IsInRange;
    public bool isDatach;
    public Animator animator;
    public Collider2D principalColllider;
    public Transform groundCheck;
    public string playerToAttack;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerToAttack).transform;
    }
    public void LookAtPlayer() 
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void Update()
    {
        animator.SetBool("isInRange", IsInRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerToAttack))
        {
            IsInRange = true;

        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerToAttack))
        {
            IsInRange = false;

        }

       
    }

 

   

    private IEnumerator Wait()
    {
        principalColllider.isTrigger = true;
        yield return new WaitForSeconds(0.5f);
        principalColllider.isTrigger = false;

    }
}
