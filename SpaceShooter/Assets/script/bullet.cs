using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private int collisionDamage = 1;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        rb.linearVelocity = Vector2.up * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    if (enemy != null)
    {
    enemy.TakeDamage(collisionDamage);
    }
     Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        collisionDamage = damage;
    }
    
}
