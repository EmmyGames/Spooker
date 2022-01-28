using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public TMP_Text score;
    private static int _totalScore;
    private const int WIN_SCORE = 25;
    public UIController ui;
    
    private void Start()
    {
        score.text = "Candies: 0/" + WIN_SCORE;
    }
    
    public static void UpdateScore(int candyScore)
    {
        _totalScore += candyScore;
    }

    public static void ResetScore()
    {
        _totalScore = 0;
    }
    private void Update()
    {
        score.text = "Candies: " + _totalScore + "/" + WIN_SCORE;
        if (_totalScore >= WIN_SCORE)
        {
            ui.Win();
        }
    }
}
