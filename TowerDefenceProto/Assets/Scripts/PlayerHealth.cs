using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 10f;
    [SerializeField] public float enemies = 50f;
    [SerializeField] int healthDecrease = 1;

    [SerializeField] Slider healthBar;
    [SerializeField] Slider progressBar;

    float startHealth;
    float targetHealth = 1;
    float FillSpeed = 0.25f;
    float targetProgress = 0;
    float startEnemyWave;


    private void Start()
    {
        healthBar.value = 1;
        progressBar.value = 0;
        startHealth = health;
        startEnemyWave = enemies;

    }

    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDecrease;
        ChangeHealthBar();
    }

    private void ChangeHealthBar()
    {
        targetHealth = health / startHealth ;
    }

    public void EnemyDied() 
    {
        enemies--;
    }
    public void ChangeProgresshBar()
    {
        targetProgress = 1 - (enemies / startEnemyWave);
    }

    private void Update()
    {
        if (healthBar.value > targetHealth)
        {
            healthBar.value -= FillSpeed * Time.deltaTime;
        }

        if (progressBar.value < targetProgress)
        {
            progressBar.value += FillSpeed * Time.deltaTime;
        }
    }
}
