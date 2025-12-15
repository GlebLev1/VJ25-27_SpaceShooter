using UnityEngine;

public class DMGBooster : MonoBehaviour
{
    [SerializeField] private StatType type;
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField]private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down * fallSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Increment(type);
            Destroy(gameObject);
        }
    }
}

public enum StatType
{
    Damage,
    ASPD
}