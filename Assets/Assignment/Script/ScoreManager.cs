using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Setting up the score text component
    private static int score = 0; //Set the int score
    static TMP_Text Text;

    void Start()
    {
        Text = scoreText;
        UpdateScoreText(); // Update score in the text
    }

    public static void IncreaseScore()
    {
        score++; // Increase score (increase by "1")
        UpdateScoreText(); // Update the score text again
    }

    static void UpdateScoreText()
    {
        // Update score text display
        Text.text = "Score: " + score.ToString();
    }
}