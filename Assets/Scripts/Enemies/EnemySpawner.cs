using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float countOfCreatures;
    [SerializeField] private float spawnRadius;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Spawner());    
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            for (int i = 0; i < countOfCreatures; i++)
            {
                Vector2 randomPosition = RandomPointInCircle() + (Vector2)transform.position;
                GameObject newEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], randomPosition, Quaternion.identity);
                newEnemy.transform.localScale = new Vector3(1,1,1);
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private Vector2 RandomPointInCircle()
    {
        float angle = Random.Range(0.0f, Mathf.PI * 2.0f);
        float distance = spawnRadius;
        return new Vector2(Mathf.Sin(angle) * distance, Mathf.Cos(angle) * distance);
    }
}
