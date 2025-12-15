using UnityEngine;

public class Damageble : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] protected int health = 3;      
    [SerializeField] protected GameManager gameManager;

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        print(gameObject.name + " levou " + damage + " de dano");

        if (health <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        if (explosion != null)
        {
            GameObject explosionInstance =
                Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionInstance, 1f);
        }
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
}
