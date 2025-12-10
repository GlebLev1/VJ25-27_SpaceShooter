using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Damageble
{
    [SerializeField] private GameObject explosion; 
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1; 
    [SerializeField] private int collisionDamage = 1;
    void Start()
    {
        rb.linearVelocity = Vector2.down * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
    Player player = collision.gameObject.GetComponent<Player>();
    if (player != null)
        {
        player.TakeDamage(collisionDamage);
        Instantiate(explosion,transform.position,Quaternion.identity);
        }
     Destroy(gameObject);
    }
}