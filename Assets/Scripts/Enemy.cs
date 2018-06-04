using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private BoxCollider boxCollider;

    [Header("Settings")]
    [Tooltip("Effects (i.e. Particle System) to activate when enemy is destroyed")] [SerializeField] GameObject deathFX;
    [Tooltip("GameObject to child the FX to")] [SerializeField] Transform parent;
    [Tooltip("Score value of destroying enemy")] [SerializeField] uint scoreValue = 100;

    [Tooltip("Health Pool of enemy. Defaults to 100.")] [SerializeField] int hitPoints = 100;

    ScoreBoard scoreBoard;
    bool isDead = false;
    int damage;

    // Use this for initialization
    void Start () {
        // Add a box collider on the enemy and the "enemy" tag
        AddNonTriggerBoxCollider();
        AddEnemyTag();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getDamage();
    }

    private void AddEnemyTag()
    {
        gameObject.tag = "Enemy";
    }

    private void AddNonTriggerBoxCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        DealDamage();
        // Kill the enemy if hp drops to or below 0
        if (this.hitPoints <= 0 && !isDead)
        {
            isDead = true;
            KillEnemy();
        }
    }

    private void DealDamage()
    {
        hitPoints -= damage;
    }

    private void KillEnemy()
    {
        // Create the deathFX instance and child it to the specified parent. Then, destroy the ship.
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        // Update score
        this.scoreBoard.IncreaseScore(scoreValue);

        Destroy(this.gameObject);
    }
}
