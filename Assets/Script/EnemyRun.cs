using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed;
    public float attackRange;
    public Transform groundCheck;

    [SerializeField] private float raycastDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    EnemieFlip enemieFlip;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemieFlip = animator.GetComponent<EnemieFlip>();
        groundCheck = enemieFlip.groundCheck;
        player = GameObject.FindGameObjectWithTag(enemieFlip.playerToAttack).transform;
        rb = animator.GetComponent<Rigidbody2D>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit2D hitGround = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastDistance, groundLayer);

        Debug.DrawRay(groundCheck.position, Vector2.down * raycastDistance, Color.red);

        if (hitGround.collider == null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }






        enemieFlip.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");

        }




    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");

    }



}
