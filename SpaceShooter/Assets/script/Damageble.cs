using UnityEngine;

public class Damageble : MonoBehaviour
{
   [SerializeField] private GameObject explosion; 
   [SerializeField] int health = 3;
   [SerializeField] GameManager gameManager;
    public void TakeDamage(int damage)
    {
        health -= damage;
        print(gameObject.name + damage + "dano");

        if(health<=0)
        {
            Die();
        }
    }

    public void Die()
    {
            Destroy(gameObject);

            if(explosion!=null)
            {
                GameObject explosionInstance = Instantiate(explosion,transform.position,Quaternion.identity);
                Destroy(explosionInstance, 1);
                gameManager.GameOver();

            }
        }
}
