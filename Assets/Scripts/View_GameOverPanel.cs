using System;
using System.Collections;
using System.Collections.Generic;
using MessagePipe;
using UnityEngine;
using VContainer;

public class View_GameOverPanel : MonoBehaviour
{
    private ISubscriber<EnumGameState> subscriber;
    private IDisposable subscriberDisposable;

    [SerializeField]
    private GameObject instructionGO;
    
    [Inject]
    public void Init(ISubscriber<EnumGameState> subscriber)
    {
        this.subscriber = subscriber;
        subscriberDisposable = subscriber.Subscribe(onGameStateChanged);
    }

    private void onGameStateChanged(EnumGameState obj)
    {
        instructionGO.SetActive(obj == EnumGameState.Dead);
    }

    private void OnDisable()
    {
        subscriberDisposable?.Dispose();
    }
}
