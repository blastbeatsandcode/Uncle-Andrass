using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour {

    [Header("Settings")]
    [Tooltip("UI element for score")] [SerializeField] TextMeshProUGUI scoreText;
    [Tooltip("Default score value if no value is passed in. Defaults to 100.")] [SerializeField] uint defaultValue = 100;

    uint score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        // Increase score every 0.5 seconds
        InvokeRepeating("AliveCounter", 0, 0.5f);
    }

    private void Update()
    {
        scoreText.text = "SCORE: " + score;
    }

    // Increases score by this value
    public void IncreaseScore (uint value)
    {
        this.score += value;

    }

    // Increases score by default value
    public void IncreaseScore()
    {
        this.score += defaultValue;
    }

    public void AliveCounter() // Referenced by string
    {
        // TODO: Put in logic for when player is alive
        // if (player.State = ALIVE) ....
        this.score += 1;
    }
}
