using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum EnemyType
{
    Shooter,
    Bomber,
    Shaman,
    Roller,
    Mangosteen,
    Smoothie
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private EnemyType type;
    [SerializeField] private int numberOfEnemies = 5;

    private int numSpawned = 0;

    public bool finishSpawning = false;

    public void SpawnEnemy()
    {
        if (numSpawned == numberOfEnemies)
        {
            finishSpawning = true;
            return;
        }
        numSpawned += 1;
        GameObject enemyInstance = 
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
