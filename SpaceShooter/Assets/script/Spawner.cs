using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject enemy;   
   void Start()
    {
      StartCoroutine(SpawnEnemy());
    }

   
    IEnumerator SpawnEnemy()
    {
       Instantiate(enemy,transform.position, Quaternion.identity);
       yield return new WaitForSeconds(2f);  
    }
}
