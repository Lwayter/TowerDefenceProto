﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 3;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    //[SerializeField] AudioClip spawnedEnemySFX;

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
        //GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
        var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.transform.parent = enemyParentTransform;
        
    }
}
