using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Transform ballCheck;
    [SerializeField] private Transform target;

    public float groundCheckDistance = 0.2f;
    public float ballCheckDistance = 1.5f;
    public float speed = 8f;
    public float jumpingPower = 16f;

    private Animator animator;
    private Rigidbody2D rb;
    private float horizontal;
    private bool isFacingRight = false;
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

        if (IsGrounded() && IsBallAbove())
        {
            Jump();
        }

        Flip();
    }

    private bool IsBallAbove()=> Physics2D.OverlapCircle(ballCheck.position, ballCheckDistance, ballLayer);

    public void Jump()
    {
        if(IsGrounded())
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        horizontal = Mathf.Sign(direction.x) * 1;
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
        Gizmos.DrawWireSphere(ballCheck.position, ballCheckDistance);
    }

    public void ResetPosition()
    {
        transform.position = spawnPosition;
    }
}
