using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScores : MonoBehaviour
{
    void Start()
    {
        // Find the text objects in the scene by their names
        TextMeshProUGUI currentScoreText = GameObject.Find("Current Score")?.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI highScoreText = GameObject.Find("Highscore")?.GetComponent<TextMeshProUGUI>();

        if (currentScoreText != null && highScoreText != null)
        {
            // Retrieve scores from PlayerPrefs
            int currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
            int highScore = PlayerPrefs.GetInt("HighScore", 0);

            // Update the text fields with the scores
            currentScoreText.text = $"You've Collected {currentScore} Coins";
            highScoreText.text = $"Your Highscore is: {highScore}";
        }
        else
        {   // if this shows up in the Logs, you mest up.
            // Increase by 1 the number below every time when your code didn't work like you intended to :)
            // 29
            Debug.LogError("Could not find the text objects named 'Current Score' and 'Highscore' in the scene.");
        }
    }
}