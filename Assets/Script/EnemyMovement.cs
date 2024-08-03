using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform groundCheck; // Transform à partir duquel le Raycast part
    public float raycastDistance = 0.5f; // Distance du Raycast
    public LayerMask groundLayer; // Couches de sol à vérifier
    public Rigidbody2D rb; // Rigidbody2D de l'ennemi
    public RigidbodyType2D currentBodyType; // Type de corps actuel du Rigidbody2D
    private bool isGrounded; // Indique si l'ennemi est au sol ou non

    
    void Update()
    {
        // Dessiner le Raycast dans la scène pour visualiser la vérification au sol
        Debug.DrawRay(groundCheck.position, Vector2.down * raycastDistance, Color.red);

        // Changer le type de corps en fonction de l'état au sol
        if (isGrounded)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Type de corps dynamique si au sol
        }
        else
        {
            rb.bodyType = currentBodyType; // Rétablir le type de corps original si pas au sol
        }
    }

    private void FixedUpdate()
    {
        // Vérifier si l'ennemi est au sol en utilisant un Raycast
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastDistance, groundLayer);

        // Déboguer l'état au sol
        Debug.Log("Is Grounded: " + isGrounded);
    }
}