using UnityEngine;

public class Enemy : Damageble
{
    [Header("Movimento e dano")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int collisionDamage = 1;

    [Header("Drop de Power Up")]
    [SerializeField] private GameObject dmgBoosterPrefab; 
    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (rb != null)
            rb.linearVelocity = Vector2.down * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(collisionDamage);
            TakeDamage(1);
        }
        else
        {
            Die();
        }
    }

    public override void Die()
    {
        TryDropPowerup();
        base.Die();
    }
    void TryDropPowerup()
    {
        if (dmgBoosterPrefab == null) return;

        float roll = Random.Range(0f, 1f);
        if (roll <= 0.3f) // 30%
        {
            Instantiate(dmgBoosterPrefab, transform.position, Quaternion.identity);
        }
    }
}
