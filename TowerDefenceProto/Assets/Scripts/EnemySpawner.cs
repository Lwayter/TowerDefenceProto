using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3;
    [SerializeField] EnemyMovement enemyPrefab;


    // Update is called once per frame
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)
        {
            SpawnNext();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void SpawnNext()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        
    }
}
