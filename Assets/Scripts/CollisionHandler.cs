using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        print("Player collided with " + collision.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        print("Player dying");
        SendMessage("DisableControls");
    }
}
