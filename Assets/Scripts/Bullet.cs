using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f; // Bullet speed
    [SerializeField] private string[] destructibleTags = { "Rock", "Bullet", "Player1", "Player2" }; // Tags the bullet can destroy

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Set the bullet's velocity if Rigidbody2D is available
        if (rb != null)
        {
            rb.velocity = transform.up * speed;
        }
    }

    private void OnBecameInvisible()
    {
        // Destroy the bullet when it goes off-screen
        DestroyBullet();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a tag that matches the destructibleTags
        foreach (var tag in destructibleTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                HandleCollisionWithTag(tag, collision);
                break;
            }
        }
    }

    private void HandleCollisionWithTag(string tag, Collision2D collision)
    {
        // Special behavior for player objects
        if (tag == "Player1" || tag == "Player2")
        {
            Destroy(collision.gameObject); // Destroy the player object
        }

        DestroyBullet(); // Destroy the bullet after collision
    }

    private void DestroyBullet()
    {
        Destroy(gameObject); // Destroy the bullet game object
    }
}
