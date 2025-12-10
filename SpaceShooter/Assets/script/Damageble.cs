using UnityEngine;

public class Damageble : MonoBehaviour
{
   [SerializeField] int health = 3;
    public void TakeDamage(int damage)
    {
    health -= damage;
    print(gameObject.name + damage + "dano");
    if(health<=0)
        {
            Destroy(gameObject);
        }
    }
}
