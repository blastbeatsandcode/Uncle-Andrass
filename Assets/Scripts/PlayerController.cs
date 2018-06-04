using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header("Weapons")]
    [Tooltip("Set all weapons used by the ship")] [SerializeField] GameObject[] guns;
    [Tooltip("Amount of damage player deals. Defaults to 10.")] [SerializeField] int damage = 10;

    [Header("Translation Settings")]
    [Tooltip("Set horizontal speed of ship when moving left and right; in ms^-1")][SerializeField] float xSpeed = 15f;
    [Tooltip("Set vertical speed of ship when moving up and down; in ms^-1")] [SerializeField] float ySpeed = 15f;

    [Tooltip("Location to clamp horizontal axis in left direction")][SerializeField] float xClampLeft = -5f;
    [Tooltip("Location to clamp horizontal axis in right direction")][SerializeField] float xClampRight = 5f;

    [Tooltip("Location to clamp vertical axis at bottom")] [SerializeField] float yClampDown = -3f;
    [Tooltip("Location to clamp vertical axis at top")] [SerializeField] float yClampUp = 3f;

    [Header("Rotation Settings")]
    [Tooltip("Position pitch factor, rotation vertically, how much to rotate")] [SerializeField] float positionPitchFactor = -5f;
    [Tooltip("Control pitch factor, rotation in Y, how far to throw")] [SerializeField] float controlPitchFactor = -15f;

    [Tooltip("Position pitch factor, rotation horizontally, how much to rotate")] [SerializeField] float positionYawFactor = 5f;
    [Tooltip("Control pitch factor, rotation in X, how far to throw")] [SerializeField] float controlYawFactor = 15f;

    [Tooltip("Control amount of roll with throw")] [SerializeField] float controlRollFactor = -15f;

    [Header("Misc Settings")]
    [Tooltip("Effect (i.e. Particle System) to show on player death")] [SerializeField] GameObject deathFX;


    float xThrow, yThrow;
    bool controlsEnabled = true;
	
	// Update is called once per frame
	void Update ()
    {
        if (controlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    private void ProcessRotation()
    {
        // Handle pitch
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        // Handle yaw
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;

        // Handle roll
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        // How far the stick has been "thrown"
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

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

    // Disable controls, called by string reference
    void DisableControls()
    {
        this.controlsEnabled = false;
    }

    // Enable controls, called by string reference
    void EnableControls()
    {
        this.controlsEnabled = true;
    }

    void HandlePlayerDeath() // Referenced by string
    {
        this.deathFX.SetActive(true);
    }

    public int getDamage()
    {
        return this.damage;
    }
}
