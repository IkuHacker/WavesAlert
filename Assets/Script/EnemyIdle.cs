using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdle : StateMachineBehaviour
{
    Rigidbody2D rb;

    public Transform groundCheck;
    [SerializeField] private float raycastDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       groundCheck = animator.GetComponent<EnemieFlip>().groundCheck;

        rb = animator.GetComponent<Rigidbody2D>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastDistance, groundLayer);

        Debug.DrawRay(groundCheck.position, Vector2.down * raycastDistance, Color.red);

       if(hit.collider == null) 
       {
            rb.bodyType = RigidbodyType2D.Dynamic;
       }
       else 
       {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        
       

    }


    

}
