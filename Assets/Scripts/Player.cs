using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Header("Physics Settings")]
    [Tooltip("Set horizontal speed of ship when moving left and right; in ms^-1")][SerializeField] float xSpeed = 8f;
    [Tooltip("Set vertical speed of ship when moving up and down; in ms^-1")] [SerializeField] float ySpeed = 8f;

    [Tooltip("Location to clamp horizontal axis in left direction")][SerializeField] float xClampLeft = -5f;
    [Tooltip("Location to clamp horizontal axis in right direction")][SerializeField] float xClampRight = 5f;

    [Tooltip("Location to clamp vertical axis at bottom")] [SerializeField] float yClampDown = -3f;
    [Tooltip("Location to clamp vertical axis at top")] [SerializeField] float yClampUp = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // How far the stick has been "thrown"
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        // Calculate the xOffset (where it will be in the window in response to the throw)
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        // Add the current position to the new xOffset so we can pass it to the new transform
        float rawNewXPos = transform.localPosition.x + xOffset;
        float rawNewYPos = transform.localPosition.y + yOffset;

        rawNewXPos = Mathf.Clamp(rawNewXPos, xClampLeft, xClampRight);
        rawNewYPos = Mathf.Clamp(rawNewYPos, yClampDown, yClampUp);

        // Here we don't add anything to the z or y axes because we are only moving horizontally
        transform.localPosition = new Vector3(rawNewXPos, rawNewYPos, transform.localPosition.z);
	}
}
