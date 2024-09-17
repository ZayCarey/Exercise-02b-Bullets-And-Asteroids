using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3.0f;
    public int damage = 1;

    void Start()
    {
        // Set the bullet's velocity
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

        // Destroy the bullet after 1 second
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        // Change color over time to fade out (optional)
        float fadeAmount = Time.deltaTime / 1f; // 1 second fade
        GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, fadeAmount);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid"))
        {
            // Destroy both bullet and asteroid
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
