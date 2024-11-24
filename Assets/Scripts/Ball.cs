using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 ballSpawnPos;
    public float force = 5f;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballSpawnPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 direction = (transform.position - collision.transform.position).normalized;
            rb.velocity = direction * force;
        }
    }

    public void ResetPosition()
    {
        transform.position = ballSpawnPos;
        rb.velocity = Vector2.zero;
        transform.rotation = Quaternion.identity;
    }
}
