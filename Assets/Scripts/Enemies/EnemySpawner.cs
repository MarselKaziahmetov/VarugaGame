using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    /// <summary>
    /// Ротация уровней волн.
    /// Описывает сущность Ротация. То есть какие параметры волн будут на этой ротации. 
    /// </summary>
    [System.Serializable]
    class WavesTierRotation
    {
        public GameObject[] enemies;
        public float timeBetweenWaves;
        public int countOfCreatures;
        public float rotationTimeToChange;
    }

    [SerializeField] private float spawnRadius;
    [SerializeField] private WavesTierRotation[] rotations; //Ротация (не связано с вращением)

    private WavesTierRotation currentRotation;
    [SerializeField]private int currentRotationIndex;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentRotation = rotations[0];
        currentRotationIndex = 0;
        StartCoroutine(Spawner());    
    }

    private void Update()
    {
        if (Time.time > currentRotation.rotationTimeToChange)
        {
            GoToNextRotation();
        }

        if (player)
        {
            transform.position = player.transform.position;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            for (int i = 0; i < currentRotation.countOfCreatures; i++)
            {
                Vector2 randomPosition = RandomPointInCircle() + (Vector2)transform.position;
                GameObject newEnemy = Instantiate(currentRotation.enemies[Random.Range(0, currentRotation.enemies.Length)], randomPosition, Quaternion.identity);
                newEnemy.transform.localScale = new Vector3(1,1,1);
            }
            yield return new WaitForSeconds(currentRotation.timeBetweenWaves);
        }
    }

    private Vector2 RandomPointInCircle()
    {
        float angle = Random.Range(0.0f, Mathf.PI * 2.0f);
        float distance = spawnRadius;
        return new Vector2(Mathf.Sin(angle) * distance, Mathf.Cos(angle) * distance);
    }

    private void GoToNextRotation()
    {
        if (rotations.Length-1 > currentRotationIndex)
        {
            currentRotationIndex++;
            currentRotation = rotations[currentRotationIndex];
        }
    }
}
