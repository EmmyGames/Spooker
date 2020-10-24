using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public TMP_Text score;
    private static int _totalScore;
    
    private void Start()
    {
        score.text = "Candies: 0";
    }
    
    public static void UpdateScore(int candyScore)
    {
        _totalScore += candyScore;
    }

    private void Update()
    {
        score.text = "Candies: " + _totalScore;
    }
}
