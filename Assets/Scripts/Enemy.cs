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

    ScoreBoard scoreBoard;
    bool isHit = false;

    // Use this for initialization
    void Start () {
        // Add a box collider on the enemy and the "enemy" tag
        AddNonTriggerBoxCollider();
        AddEnemyTag();
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        if (!isHit) // Prevent from multiple particle collisions before delete
        {
            isHit = true;
            // Update score
            this.scoreBoard.IncreaseScore(scoreValue);

            // Create the deathFX instance and child it to the specified parent. Then, destroy the ship.
            GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;

            Destroy(this.gameObject);
        }
    }
}
