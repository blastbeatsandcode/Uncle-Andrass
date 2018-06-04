using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    [Header("Misc Settings")]

    [Tooltip("Length of time before self destruct. Defaults to 3 seconds")] [SerializeField] float timeUntilSelfDestruct = 3f;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, timeUntilSelfDestruct);
	}
}
