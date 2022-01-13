using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using TMPro;
using UnityEngine;
using VContainer.Unity;

public class PointScoring : IInitializable, IDisposable
{
    public int Score { get; private set; }
    private View_ScoreText scoreText;
    private ISubscriber<string> scoreSubscriber;
    private IDisposable subscriberDisposable;
    
    public PointScoring(View_ScoreText scoreText, ISubscriber<string> subcsriber)
    {
        this.scoreText = scoreText;
        this.scoreSubscriber = subcsriber;
    }
    
    public void Initialize()
    {
        Score = 0;
        SetScoreText(Score.ToString());
        subscriberDisposable = scoreSubscriber.Subscribe(onPointScoredMessage);
    }

    private void onPointScoredMessage(string obj)
    {
        if (obj == "Point Scored")
            AddScore();
    }

    void AddScore()
    {
        Score+=1;
        SetScoreText(Score.ToString());
    }

    void SetScoreText(string msg)
    {
        scoreText.SetScore(msg);
    }

    public void Dispose()
    {
        subscriberDisposable?.Dispose();
    }
}
