using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider colliderMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

    PlayerHealth player;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    private void KillEnemy()
    {
        player.EnemyDied();
        player.ChangeProgresshBar();
        var vfx = Instantiate(deathParticlePrefab, gameObject.transform.position, Quaternion.identity);
        vfx.Play();
        float destroyDelay = vfx.main.duration;
        Destroy(vfx.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
}
