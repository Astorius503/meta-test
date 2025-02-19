using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlappyBird : MonoBehaviour
{
    public float jumpForce = 5f; // Á¡ÇÁ Èû
    private Rigidbody2D rb;
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            isGameOver = true;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}

