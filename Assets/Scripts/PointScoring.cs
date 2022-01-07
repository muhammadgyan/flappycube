using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PointScoring : IInitializable
{
    public int Score { get; private set; }
    private TextMeshProUGUI scoreText;

    public PointScoring(TextMeshProUGUI scoreText)
    {
        this.scoreText = scoreText;
    }
    
    public void Initialize()
    {
        Score = 0;
        SetScoreText(Score.ToString());
    }

    public void AddScore()
    {
        Score+=1;
        SetScoreText(Score.ToString());
    }

    void SetScoreText(string msg)
    {
        scoreText.text = msg;
    }
}
