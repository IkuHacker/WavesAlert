using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.EventSystems;


public class PlayerOneMovement : MonoBehaviour, IPointerClickHandler
{
    [Header("Movement")]
    public float moveSpeed = 10f;
    private float horizontalMovement;
    public bool isFacingRight = true;

    private Vector3 velocity = Vector3.zero;


    [Header("Jump")]
    private bool isGrounded;
    private bool isJumping;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    public float jumpForce = 350f;

   

  

    [Header("Verificator")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raycastDistance = 0.2f;


    [Header("Other")]
    public Rigidbody2D rb;
    public Animator animator;
    public EventSystem eventSystem;
    public GameObject objectToSelect;
    public Transform bow;



    public static PlayerOneMovement instance;

    private float afterimageSpawnTimer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la sc�ne");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if(Input.GetMouseButton(1) || Input.GetMouseButton(0) || Input.GetMouseButton(2)) 
        {
            eventSystem.SetSelectedGameObject(objectToSelect);

        }

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastDistance, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * raycastDistance, Color.red);

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if ((jumpBufferCounter > 0f && coyoteTimeCounter > 0f))
        {
            isJumping = true;
            jumpBufferCounter = 0f;
        }


        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

       
        Flip();
        


        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("speed", characterVelocity);
        animator.SetBool("isJumping", !isGrounded);

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastDistance, groundLayer);
        MovePlayer(horizontalMovement);
    }

    public void MovePlayer(float _horizontalMovement)
    {
        
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        
        
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;

            Vector3 bowLocalScale = bow.localScale;
            bowLocalScale.x *= -1f;
            bow.localScale = bowLocalScale;

            
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        eventSystem.SetSelectedGameObject(objectToSelect);
    }



}

