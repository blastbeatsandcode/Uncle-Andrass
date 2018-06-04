using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    private BoxCollider boxCollider;

    [Header("Settings")]
    [Tooltip("Effects (i.e. Particle System) to activate when enemy is destroyed")] [SerializeField] GameObject deathFX;
    [Tooltip("GameObject to child the FX to")] [SerializeField] Transform parent;

    bool isHit = false;

    // Use this for initialization
    void Start () {
        // Add a box collider on the enemy and the "enemy" tag
        AddNonTriggerBoxCollider();
        AddDestructableTag();
	}

    private void AddDestructableTag()
    {
        gameObject.tag = "Destructable";
    }

    private void AddNonTriggerBoxCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        // Create the deathFX instance and child it to the specified parent. Then, destroy the ship.
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        Destroy(this.gameObject);
    }
}
