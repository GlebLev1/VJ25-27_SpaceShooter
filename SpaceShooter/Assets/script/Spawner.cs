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
        while (true)
        {
            float randomX = Random.Range(-7f, 10f);

            Vector3 spawnPos = new Vector3(randomX, transform.position.y, transform.position.z);
            Instantiate(enemy, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
