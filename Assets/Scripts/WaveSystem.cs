using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [Serializable]
    public class Wave
    {
        [Serializable]
        public class EnemyGroup
        {
            public Enemy prefab; //The prefab to spawn
            public int maxSpawns; //How many of these enemies have this wave
            //[HideInInspector] 
            public int spawnedCount; //How many of these have already spawned
        }

        //[HideInInspector]
        public int maxSpawnedEnemies; //Max enemies to spawn this wave
        //[HideInInspector]
        public int currentSpawnedEnemies; //Current spawned enemies
        public float spawnInterval; //How often spawn an enemy
        public List<EnemyGroup> enemyGroups;
    }

    [SerializeField] private Transform playerTransform;
    [SerializeField] private List<Wave> waves;
    [SerializeField] float waveInterval;
    [SerializeField] private int maxEnemiesAllowed; //Allowed in game
    
    private int currentWave;
    private float timeToSpawnEnemies;
    private int currentEnemiesAlive;
    private bool maxEnemiesReached;
    
    private void Start()
    {
        CalculateMaxEnemies();
        TrySpawnEnemy();
    }

    private void Update()
    {
        timeToSpawnEnemies += Time.deltaTime;

        if (currentWave < waves.Count && waves[currentWave].currentSpawnedEnemies == waves[currentWave].maxSpawnedEnemies)
        {
            StartCoroutine(nameof(BeginNextWave));
        }
        
        if (timeToSpawnEnemies >= waves[currentWave].spawnInterval)
        {
            TrySpawnEnemy();
            timeToSpawnEnemies = 0f;
        }
    }

    private IEnumerator BeginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if (currentWave < waves.Count - 1)
        {
            currentWave++;
            CalculateMaxEnemies();
        }
    }

    private void CalculateMaxEnemies()
    {
        var totalEnemies = 0;
        foreach (var group in waves[currentWave].enemyGroups)
        {
            totalEnemies += group.maxSpawns;
        }

        waves[currentWave].maxSpawnedEnemies = totalEnemies;
    }

    private void TrySpawnEnemy()
    {
        var wave = waves[currentWave];

        if (wave.currentSpawnedEnemies < wave.maxSpawnedEnemies && !maxEnemiesReached)
        {
            foreach (var group in wave.enemyGroups)
            {
                if (group.spawnedCount < group.maxSpawns)
                {
                    if (currentEnemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }
                    SpawnEnemy(group.prefab);
                    wave.currentSpawnedEnemies++;
                    group.spawnedCount++;
                    currentEnemiesAlive++;
                }
            }
        }

        if (currentEnemiesAlive < maxEnemiesAllowed)
            maxEnemiesReached = false;
    }

    private void SpawnEnemy(Enemy prefab)
    {
        var clone = Instantiate(prefab);
        clone.Init(playerTransform);
        clone.OnEnemyKilled += OnEnemyKilled;
    }

    private void OnEnemyKilled()
    {
        currentEnemiesAlive--;
    }
}