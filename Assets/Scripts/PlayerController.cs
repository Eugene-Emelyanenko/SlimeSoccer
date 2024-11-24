using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public float groundCheckDistance = 0.2f;
    public float speed = 8f;
    public float jumpingPower = 16f;

    private Animator animator;
    private Rigidbody2D rb;
    private float horizontal;
    private bool isFacingRight = true;
    private Vector2 spawnPosition;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spawnPosition = transform.position;
    }

    void Update()
    {
        if(IsGrounded())
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        else
            animator.SetFloat("Speed", 0);
        
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() => Physics2D.OverlapCircle(groundCheck.position, groundCheckDistance, groundLayer);

        private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckDistance);
    }

    public void MoveRight()
    {
        horizontal = 1;
    }
    public void MoveLeft()
    {
        horizontal = -1;
    }
    public void StopMoving()
    {
        horizontal = 0;
    }

    public void Jump()
    {
        if(IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    public void ResetPosition()
    {
        transform.position = spawnPosition;
    }
}
