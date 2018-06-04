using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Header("Collision Settings")]
    [Tooltip("Amount of time before reloading level.")] [SerializeField] float levelLoadDelay = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        print("Player collided with " + collision.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    // Reloads current scene
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartDeathSequence()
    {
        // SendMessage calls the function DisableControls() by string
        SendMessage("DisableControls");
        SendMessage("HandlePlayerDeath");
        Invoke("ReloadScene", levelLoadDelay);
    }
}
