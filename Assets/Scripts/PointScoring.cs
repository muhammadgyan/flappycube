using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using TMPro;
using UnityEngine;
using Zenject;

public class PointScoring : IInitializable, IDisposable
{
    public int Score { get; private set; }
    private TextMeshProUGUI scoreText;
    private ISubscriber<string> scoreSubscriber;
    private IDisposable subscriberDisposable;
    
    public PointScoring(TextMeshProUGUI scoreText, MessagePipeManager messagePipeManager)
    {
        this.scoreText = scoreText;
        this.scoreSubscriber = messagePipeManager.stringSubscriber;
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
        scoreText.text = msg;
    }

    public void Dispose()
    {
        subscriberDisposable?.Dispose();
    }
}
